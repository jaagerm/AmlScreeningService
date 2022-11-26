# AmlScreeningService
This is an application to check name matches from a pre-determined list of sanctioned individuals.

Application build constraints, compared to the original requirements:
- **Written in .NET 6 instead of Java** - due to the reason of better adhering to the time limit of a few hours to complete the task, given the author's differing experience in .Net vs Java and therefore the familiarity differences between libraries. But the logic still stands, no matter which language. If needed, the application can easily be ported to Java, but would take twice or more the time at the current moment from the author. 
- **Sanctioned individual's list is in CSV format, at the root of the project** - the originally provided link to the sanctioned individual's list was broken. So the author improvised, and downloaded a CSV file containing a list of sanctioned individuals from https://www.eeas.europa.eu/eeas/european-union-sanctions_en instead.
- **The application uses an internal custom cache to store the data** - in stead of a full-feature in memory database, such as EntityFramework, which seems a bit of an overkill in the current situation.

## Requirements for running this application
- Have .NET 6 installed

## How to build and run on Windows
- Clone this repository
- navigate to the root folder of this repository in console
- run "dotnet build"
- run "dotnet run AmlScreeningService\bin\Debug\net6.0\AmlScreeningService.exe"
- Example of api usage. Change name value as neccessary: "https://localhost:7230/amllist?name=Marat Siarheevich MARKAU"

## Additional notes about AWS hosting and strucutre
- Regarding hosting - the application could be hosted on EKS (Elastic Kubernetes Service) with an API gateway in front of it, for managing and securing the API connectivity to the outside world (if needed).
- If there is heavy traffic to the API endpoint, the application should be able to run mupltiple replicas of itself on EKS for scaling purposes.
- If we want ease of use and AWS's own container orchestration, we can use ECS (Elastic Container Service) as well.
- If the API needs to be for company use only, then we could integrate AWS Cognito in front of AWS API Gateway to manage user access.