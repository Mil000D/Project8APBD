# Project 8 : Summary

The project includes the following tasks:

1. Endpoint Security: Secure all endpoints to ensure they are only accessible to logged-in users. Implement JWT authentication to validate incoming requests with a correct token.

2. `AccountsController`: Add a controller named `AccountsController` that includes a login method. This method accepts a login and password and returns a new token along with a refresh token. Utilize suitable techniques (e.g., SALT, PBKDF2) to securely store sensitive user data in the database. Also, create a new migration to store user information in the database.

3. Refresh Token Endpoint: Create an endpoint that allows obtaining a new access token based on a refresh token. Users can use this endpoint to refresh their authentication token without re-entering login credentials.

4. Custom Error Logging Middleware: Implement a custom middleware to log all errors to a text file named `logs.txt`. This middleware will capture and record any occurring errors for easier debugging and troubleshooting.

