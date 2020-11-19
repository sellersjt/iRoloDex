# iRoloDex

iRoloDex is an online rolodex housing different households containing individuals contact information. iRoloDex was developed using .Net Framework and C# programming language ultilizing entity relationships.

## Install iRoloDex Locally
1. Clone repo from GitHub.
2. Once everything is loaded in Visual Studio or your text editor double click on the iRolodex.sln file.
3. Select the IIS Express button to launch application

## Running iRolodex
1. Navigate to the Swagger tab at the top of the webpage.
2. Select Account.
    1. From the drop down menu select POST /api.Account/Register.
    2. To make this process easier navigate to the right side of the screen and select the Model Example Value.
    3. This will input the information needed in the Body for you to register.
    4. Complete the Email, Password, and ConfirmPassword fields.
    5. Select Try it out! to submit your request.
        1. Return type 200 will let you know you've sucessfully registered.
3. Select Auth.
      1. Select POST /token.
      2. Input username and password to retreive your token.
      3. Select Try it out! to submit your request.
      4. Copy your token from the Response Body.
        1. It will be located in the "access-token" field.
4. Select Owner.
    1. Select POST /api/Owner.
    2. To make this process easier navigate to the right side of the screen and select the Model Example Value.
    3. Input your name and email address. ***Ignore UserId***
    4. Select Try it out! to submit your request.
      1. Return type 200 will let you know you request was sucessfully.
5. Select Relationship.
    1. Select POST /api/Relationship.
    2. Navigate to the right side of the screen and select the Model Example Value.
    3. Input relationshipType.
        1. This could be anyone of the following and you can make this whatever you like these are just examples:
            1. Family
            2. Friend
            3. Co-worker/Colleauge
            4. Prospect
    4. Select Try it out! to submit your request.
        1. Return type 200 will let you know you request was sucessfully.
6. Select Household.
    1. Select POST api/Household
    2. Navigate to the right side of the screen and select the Model Example Value.
    3. Input the following:
        1. Street Address
        2. City
        3. State
        4. Zip
        5. ownerId
            1. If you don't remember the ownerId assigned to you, you can navigate back to the Owner tab and view your body response.
            2. If you've closed out of this or it's no longer displaying you can do the following:
                1. Select GET /api/Owner
                2. Enter your token.
                    1. ***bearer*** followed by your token to ensure access to the data.
    6. Select Try it out! to submit your request.
        1. Return type 200 will let you know you request was sucessfully
7. Person
    1. Select POST api/Person.
    2. Navigate to the right side of the screen and select the Model Example Value.
    3. Input the following:
        1. OwnerId
            1. If you don't remember the ownerId assigned to you, you can navigate back to the Owner tab and view your body response.
            2. If you've closed out of this or it's no longer displaying you can do the following:
                1. Select GET /api/Owner
                2. Enter your token.
                    1. ***bearer*** followed by your token to ensure access to the data
        2. HouseholdId
            1. If you don't remember the HouseholdId assigned to you, you can navigate back to the Household tab and view your body response.
            2. If you've closed out of this or it's no longer displaying you can do the following:
                1. Select GET /api/Household
                2. Enter your token.
                    1. ***bearer*** followed by your token to ensure access to the data.
        3. RelationshipId
            1. If you don't remember the RelationshipId assigned to you, you can navigate back to the Owner tab and view your body response.
            2. If you've closed out of this or it's no longer displaying you can do the following:
                1. Select GET /api/Relationship
                2. Enter your token.
                    1. ***bearer*** followed by your token to ensure access to the data.
    4. LastName
    5. FirstName
    6. PhoneNumber
    7. Email
  4. Select Try it out! to submit your request.
    1. Return type 200 will let you know you request was sucessfully
      

## Resources:
### Web API Help Page
https://docs.microsoft.com/en-us/aspnet/web-api/overview/getting-started-with-aspnet-web-api/creating-api-help-pages
### Swagger
https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-5.0&tabs=visual-studio
### Markdown Syntax
https://www.markdownguide.org/basic-syntax
