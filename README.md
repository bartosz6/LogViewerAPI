# LogViewer api
.NET Core + CQRS

## Test environment
http://logviewerapi.azurewebsites.net/

## How to run it locally
1. Clone or download repository
2. Install .NET Command Line Tools (1.0.1)
3. Copy varnish.log file into /Web subdirectory
4. Use 'dotnet run' from /Web subdirectory

## Endpoints
### /api/logs
#### Filters:
##### code /int/
Response code
example:
/api/logs?code=200

##### text /string/
Fulltext search
example:
/api/logs?text=static

##### startDate /datetime/
Minimal date of log that will be returned
example:
/api/logs?startDate=2012-05-23T22:00:00.000Z

##### endDate /datetime/
Maximal date of log that will be returned
example:
/api/logs?endDate=2012-05-23T22:00:00.000Z

#### Sorting
##### orderBy /string/
Column name to order by
example:
/api/logs?orderBy=date

##### desc /bool/
Descending sort
/api/logs?desc=true

#### Pagination
##### start /int/
How many items should be skipped
/api/logs?start=123

##### limit /int/
How many items should be returned
/api/logs?limit=15

## Missing features
Unfortunately I did not have enough time to implement many things:
- good error handling
- log file url moved to config
- more handsome routes
- proper query default values
- tests

## Used libs
1. .NET Core
