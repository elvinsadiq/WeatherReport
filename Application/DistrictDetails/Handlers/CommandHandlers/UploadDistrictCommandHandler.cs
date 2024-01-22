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
            try
            {
                using (var streamReader = new StreamReader(request.XmlData.OpenReadStream()))
                {
                    // Read the content of the file
                    string xmlContent = await streamReader.ReadToEndAsync();

                    XmlDocument xmlDoc = new XmlDocument();

                    xmlDoc.LoadXml(xmlContent);

                    XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlDoc.NameTable);
                    nsManager.AddNamespace("ss", "urn:schemas-microsoft-com:office:spreadsheet");


                    // Assuming there's a root node (e.g., <Workbook>) and the data is inside a specific worksheet (e.g., <Table1>)
                    XmlNodeList rowNodes = xmlDoc.SelectNodes("/ss:Workbook/ss:Worksheet[@ss:Name='Table1']/ss:Table/ss:Row", nsManager);

                    foreach (XmlNode rowNode in rowNodes)
                    {
                        // Extract values from each "Cell" node in the current row
                        XmlNodeList cellNodes = rowNode.SelectNodes("ss:Cell/ss:Data", nsManager);

                        if (cellNodes != null && cellNodes.Count == 4)
                        {
                            // Extract values from Data nodes
                            string id = cellNodes[0].InnerText;
                            string title = cellNodes[1].InnerText;
                            string latitude = cellNodes[2].InnerText;
                            string longitude = cellNodes[3].InnerText;

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
                    }

                    return new UploadDistrictCommandResponse { IsSuccess = true };
                }
            }
            catch (Exception ex)
            {
                // Log the entire exception for debugging purposes
                Console.WriteLine(ex.ToString());

                throw new Exception(ex.Message);
            }

        }
    }
}