# EmpAPI
A Simple REST API in ASP.Net Core

This API can be used as a simple employee register. An employee has - First Name, Last Name, Date of Joining, Manager, IsActive(true/false). The API uses an in-memory database for data persistence. The table below shows the endpoints and the response.

| API End Point | Description | Request Body | Response Body |
|----------------------|--------------------------------------------------------------------------------------------------|-----------------------------------------|--------------------|
| GET /api/emp | Get all employees | None | Array of Employees |
| GET /api/emp/{id} | Get employee by id | None | Employee |
| POST /api/emp | Add a new employee  (DateOfJoining is set to current date/time by default  isActive set to true) | Employee– FirstName,  LastName, Manager | Employee |
| PUT /api/emp/{id} | Update an existing employee | Employee | None |
| DELETE /api/emp/{id} | Delete an employee | None | None |
