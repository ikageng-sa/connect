# Connect - Disaster Relief Donation Management Web Application

This project is a C# web application developed using the .NET Framework to assist an organization in recording donations and managing disaster relief efforts. The application allows users to record various types of donations, including monetary donations, as well as categorize them based on their type. Users can also utilize monetary donations to record new purchases, document disasters, and allocate donations to alleviate specific disasters.

## Note

This project was initially developed as a school project, aiming to provide a solution for managing donations and disaster relief efforts within organizations.

## Setup Instructions

1. **Clone the Repository:**
    - Clone the repository to your local machine using the command:
      ```
      git clone https://github.com/ikageng-sa/connect.git
      ```

2. **Connect to Database:**
    - Locate the `appsettings.json` file in the base directory of the project.
    - Open the `appsettings.json` file and paste your database connection string in the appropriate field.
    - Save the `appsettings.json` file.

3. **Update Database:**
    - Run the package manager to update the database schema according to the changes made to the `appsettings.json` file using the command:
        ```
        update-database
        ```

## Tools Used

- **Microsoft Visual Studio:** This project was developed using Microsoft Visual Studio IDE.
- **.NET Framework:** The project is built using the .NET Framework.
- **UnitTesting:** This project utilizes the Microsoft.VisualStudio.TestTools.UnitTesting framework for unit testing.
- **Entity Framework Core:** For database operations, Entity Framework Core is used.
- **ASP.NET MVC:** The project is built using ASP.NET MVC for web application development.


## Contributing

This project is open to contributions. If you wish to make changes to the application:

Feel free to fork the repository and make your changes.
    If the change is substantial, please consider opening an issue on GitHub to discuss it before submitting a pull request.

