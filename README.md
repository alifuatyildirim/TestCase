User Activity Service\
=====================

📖 Table of Contents\
--------------------

1\. [Summary](#summary)\
2\. [Details](#details)\
3\. [Solution](#solution)\
- [System Design](#system-design)\
- [Technologies Used](#technologies-used)\
- [Setting Up the Project](#setting-up-the-project)\
- [Running Tests](#running-tests)\
  4\. [Usage](#usage)\
- [Creating an Activity](#creating-an-activity)\
- [Get User Activities](#get-user-activities)\
- [Get All Activities](#get-all-activities)\
  5\. [More Information](#more-information)

🌟 Summary\
----------

This project is a CRUD application designed to manage user activity information. The system records various activities such as login, page views, transactions, etc., and provides reporting capabilities. It ensures data integrity through enforced uniqueness constraints on certain fields.

📋 Details\
----------

1\. Users are represented with attributes like UserId, Name, Email, JoinDate, etc.\
2\. Activities are logged with attributes such as ActivityId, UserId, ActivityType, ActivityDate, Description, etc.\
3\. The application enforces uniqueness constraints on users based on Name, Email, and other specified fields.\
4\. Validations are performed during user creation/update to maintain data integrity.

🚀 Solution\
-----------

### 🛠️ System Design

The application is built using .NET Core with a focus on clean architecture. It implements Domain-Driven Design (DDD) principles for modeling entities and interactions. The Command Query Responsibility Segregation (CQRS) pattern is used for separating command and query operations. Event sourcing is employed for persisting and retrieving entity states.

### 💻 Technologies Used

- .NET Core\
- MongoDB (Clustered)\
- Docker

### 🏗️ Setting Up the Project

1\. Clone the repository.\
2\. Navigate to the project directory.\
3\. Build and run the Docker containers: `docker-compose up -d`

**MongoDB Cluster Setup:**

- Use Docker Compose files for MongoDB settings.

Refer to [Deploying a MongoDB Cluster with Docker](https://www.mongodb.com/compatibility/deploying-a-mongodb-cluster-with-docker) for detailed instructions.

### 🧪 Running Tests

1\. Ensure project dependencies are installed: `dotnet restore`\
2\. Run integration tests: `dotnet test TestCase.Api.Integration.Test`\
3\. Run unit tests: `dotnet test TestCase.Api.UnitTest`

🚀 Usage\
--------

### 📝 Creating an Activity

To create a new activity, send a POST request to the following endpoint:

POST /activities

Include the following JSON payload:
```

{
  "name": "string",
  "email": "string", //If userId is full, name and surname can be empty.
  "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",  // If userId name and email are full, it can be nullable.
  "activityType": "Signup", // If ActivityType is Signup, a new user will be created, ActivityTypes : Signup,Login,Pageview
  "description": "string"
}
```

### 🔄 Get User Activities

To retrieve activities for a specific user, send a GET request to the following endpoint:

GET /users/{userId}/activities

### 📈 Get All Activities

To list all activities, optionally filtered, send a GET request to the following endpoint:

GET /activities

📚 More Information\
-------------------

For more details on deploying a MongoDB Cluster with Docker, visit [MongoDB Cluster Deployment](https://www.mongodb.com/compatibility/deploying-a-mongodb-cluster-with-docker).

Note: While transactions are not currently implemented in this project, MongoDB's clustered setup provides a robust foundation for future transactional requirements.