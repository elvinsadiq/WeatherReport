using Application.DistrictDetails.Commands.Request;
using Application.DistrictDetails.Commands.Response;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Application.DistrictDetails.Handlers.CommandHandlers
{
    public class UploadDistrictCommandHandler : IRequestHandler<UploadDistrictCommandRequest, UploadDistrictCommandResponse>
    {
        private readonly IDistrictRepository _repository;
        private readonly IMapper _mapper;

        public UploadDistrictCommandHandler(IDistrictRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UploadDistrictCommandResponse> Handle(UploadDistrictCommandRequest request, CancellationToken cancellationToken)
        {

            using (var streamReader = new StreamReader(request.XmlData.OpenReadStream()))
            {
                // Read the content of the file
                string xmlContent = await streamReader.ReadToEndAsync();

                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.LoadXml(xmlContent);

                // Assuming there's a root node (e.g., <Workbook>) and the data is inside a specific worksheet (e.g., <Table1>)
                XmlNodeList rowNodes = xmlDoc.SelectNodes("//Worksheet[@ss:Name='Table1']/Table/Row");

                foreach (XmlNode rowNode in rowNodes)
                {
                    // Extract data from each cell
                    string id = rowNode.SelectSingleNode("Cell[1]/Data")?.InnerText;
                    string title = rowNode.SelectSingleNode("Cell[2]/Data")?.InnerText;
                    string latitude = rowNode.SelectSingleNode("Cell[3]/Data")?.InnerText;
                    string longitude = rowNode.SelectSingleNode("Cell[4]/Data")?.InnerText;

                    // Create a District entity and map values
                    District district = new District
                    {
                        Id = int.Parse(id),
                        Title = title,
                        Latitude = latitude,
                        Longitude = longitude
                    };

                    // Check if the district already exists in the database
                    var existingDistrict = await _repository.FirstOrDefaultAsync(p => p.Id == district.Id);
                    if (existingDistrict == null)
                    {
                        // District doesn't exist, so insert it
                        await _repository.AddAsync(district);
                        await _repository.CommitAsync();
                    }
                    else
                    {
                        // District already exists, update it if needed
                        _mapper.Map(district, existingDistrict);
                        await _repository.UpdateAsync(district);
                    }
                }

                return new UploadDistrictCommandResponse { IsSuccess = true };
            }
        }
    }
}