# WeatherReport API

## Overview
WeatherReport is a .NET Core Web API project built on .NET 6.0, designed to fetch and store weather information for various cities using the OpenWeatherMap API. This application leverages clean architecture and the CQRS MediatR pattern to provide a robust and scalable solution for managing weather data.

## Features
- **Weather Data Fetching**: Utilizes OpenWeatherMap.com's API to gather weather information based on the longitude and latitude coordinates of cities.
- **XML Uploads**: Supports uploading of XML files containing longitude and latitude coordinates for cities, making it easy to add new locations.
- **Background Service**: Includes a `WeatherReportService` that runs every 3 hours to update weather information for all tracked districts.
- **Comprehensive Weather Details**: Captures a wide range of weather data, including:
  - District ID
  - Weather ID
  - Main weather description
  - Detailed description
  - Icon representation
  - Temperature (current, feels like, min, max)
  - Atmospheric pressure
  - Humidity levels
  - Sea level
  - Ground level
  - Wind speed, degree, and gust
  - Cloudiness percentage

## Technologies
- .NET 6.0
- CQRS with MediatR Pattern
- MySQL Database
- OpenWeatherMap API

## Getting Started

### Prerequisites
- .NET 6.0 SDK
- MySQL Server

### Setup
1. Clone the repository to your local machine.
2. Set up your MySQL database and DefaultConnectionString string inside of appsettings.json.
3. Run the database migration scripts provided in the `./Infrastructure/Migrations` folder to set up your database schema. Open "Package Manager Console". Selecet Infrastructure as a Default project. Then type "update-database"

### Running the Application
1. Right click on "WeatherReport" ASP.NET Core Web API project at the Solution Explorer then click "Set as Startup Project"

### Uploading City Coordinates
1. Prepare an XML file with the longitude and latitude coordinates of your cities.
Here as example for xml data that is used in this project:

<?xml version="1.0"?>
<?mso-application progid="Excel.Sheet"?>
<Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet"
 xmlns:o="urn:schemas-microsoft-com:office:office"
 xmlns:x="urn:schemas-microsoft-com:office:excel"
 xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet"
 xmlns:html="http://www.w3.org/TR/REC-html40">
 <DocumentProperties xmlns="urn:schemas-microsoft-com:office:office">
  <Version>16.00</Version>
 </DocumentProperties>
 <OfficeDocumentSettings xmlns="urn:schemas-microsoft-com:office:office">
  <AllowPNG/>
 </OfficeDocumentSettings>
 <ExcelWorkbook xmlns="urn:schemas-microsoft-com:office:excel">
  <WindowHeight>9585</WindowHeight>
  <WindowWidth>21600</WindowWidth>
  <WindowTopX>32767</WindowTopX>
  <WindowTopY>32767</WindowTopY>
  <ProtectStructure>False</ProtectStructure>
  <ProtectWindows>False</ProtectWindows>
 </ExcelWorkbook>
 <Styles>
  <Style ss:ID="Default" ss:Name="Normal">
   <Alignment ss:Vertical="Bottom"/>
   <Borders/>
   <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
   <Interior/>
   <NumberFormat/>
   <Protection/>
  </Style>
 </Styles>
 <Worksheet ss:Name="Table1">
  <Table ss:ExpandedColumnCount="4" ss:ExpandedRowCount="69" x:FullColumns="1"
   x:FullRows="1" ss:DefaultColumnWidth="51" ss:DefaultRowHeight="14.25">
   <Column ss:Index="2" ss:AutoFitWidth="0" ss:Width="109.875" ss:Span="2"/>
   <Row>
    <Cell><Data ss:Type="String">id</Data></Cell>
    <Cell><Data ss:Type="String">title</Data></Cell>
    <Cell><Data ss:Type="String">latitude</Data></Cell>
    <Cell><Data ss:Type="String">longitude</Data></Cell>
   </Row>
   <Row>
    <Cell><Data ss:Type="Number">1</Data></Cell>
    <Cell><Data ss:Type="String">Madrid</Data></Cell>
    <Cell><Data ss:Type="String">40.41</Data></Cell>
    <Cell><Data ss:Type="String">3.70</Data></Cell>
   </Row>
   </Table>
  <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
   <Selected/>
   <Panes>
    <Pane>
     <Number>3</Number>
     <ActiveCol>2</ActiveCol>
     <RangeSelection>C3</RangeSelection>
    </Pane>
   </Panes>
   <ProtectObjects>False</ProtectObjects>
   <ProtectScenarios>False</ProtectScenarios>
  </WorksheetOptions>
 </Worksheet>
</Workbook>

## Background Service
The `WeatherReportService` background service is configured to run every 3 hours automatically. It fetches and updates the weather information for all cities in the database based on their longitude and latitude coordinates.

## Contributing
Contributions are welcome! Please feel free to submit pull requests or open issues to suggest improvements or add new features.

## License
This project is licensed under the MIT License - see the LICENSE file for details.
