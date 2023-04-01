To launch the solution:
1- Open cmd in catalog-client folder and run the command "npm install"
2- Run command "npm start"
3- Open the solution with Visual Studio and open Solution/Properties/Startup Project and set it to "Multiple startup projects" with the CatalogApi and 
the CatalogIngestionWorker
4- Run the application in Visual Studio.
5- The Web Api should launch along with the Worker.
6- Use the catalog-client to upload a file.


Notes:
Tests answers:
1- All the written answers are in the file Written answers.pdf in the root folder
2- The html test code is under html-test folder. Just open the folder and double click the index.html file.
3- The Catalog test (for the data ingestion) was resolved from an Architecture perspective.
So, I concentrated mainly on the structure and not on implementation details. For the sake of time, the logic to actually read from an FTP server
was not implemented.
4- Also, in the FE side, you can find the logic structure, but not the actuall implementation of a file upload and the process of sending
the actual file to the server. We are sending dummy data in order to code faster.
5- As you will see, a lot of code was written in a short period of time. So, there was no enough time for actual implementation.
