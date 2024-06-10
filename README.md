# Gym Management Project Documentation

## Overview

The Gym Management Project is a web application designed to assist gym owners in managing their gym operations efficiently. The application is built using ASP.NET MVC Core 2.1 and SQL Server. The system supports two types of users: Admin and Sub-Client User, each with distinct roles and responsibilities.

## Features

### Admin Features
- **Add New Batch**: Create and manage gym batches.
- **Create New User**: Add and manage new users (staff, trainers, etc.).
- **Add New Trainer**: Register and manage trainers.
- **Add New Plans**: Define and manage membership plans.
- **Add New Members**: Register and manage gym members.

### Sub-Client User Features
- **Assign Trainer**: Assign trainers to members.
- **Maintain Member Fees**: Track and manage member fees.
- **Add New Members**: Register and manage gym members.

## System Architecture

### Technologies Used
- **Backend**: ASP.NET MVC Core 2.1
- **Database**: SQL Server
- **Frontend**: HTML, CSS, JavaScript
- **Libraries**: jQuery, Select2

### Project Structure
- **Controllers**: Handles the request and response cycle.
- **Models**: Represents the data and business logic.
- **Views**: Renders the user interface.
- **Migrations**: Manages database schema changes.

## Database Schema

The database schema includes the following tables:
- **Users**: Stores user details including roles.
- **Members**: Stores member information.
- **Batches**: Stores batch details.
- **Trainers**: Stores trainer details.
- **Plans**: Stores membership plans.
- **Fees**: Stores member fee details.

## User Roles and Permissions

### Admin
Admins have full access to all features and functionalities of the system, including creating and managing batches, users, trainers, plans, and members.

### Sub-Client User
Sub-client users have restricted access. They can assign trainers, maintain member fees, and add new members but cannot create batches, users, or plans.

## Functionality

### Adding New Batch
1. **Access**: Admin
2. **Steps**:
   - Navigate to the "Batches" section.
   - Click on "Add New Batch".
   - Fill in the batch details (name, timing, etc.).
   - Submit to save the batch.

### Creating New User
1. **Access**: Admin
2. **Steps**:
   - Navigate to the "Users" section.
   - Click on "Add New User".
   - Fill in user details (name, role, email, etc.).
   - Submit to save the user.

### Adding New Trainer
1. **Access**: Admin
2. **Steps**:
   - Navigate to the "Trainers" section.
   - Click on "Add New Trainer".
   - Fill in trainer details (name, expertise, etc.).
   - Submit to save the trainer.

### Adding New Plans
1. **Access**: Admin
2. **Steps**:
   - Navigate to the "Plans" section.
   - Click on "Add New Plan".
   - Fill in plan details (name, duration, cost, etc.).
   - Submit to save the plan.

### Adding New Members
1. **Access**: Admin, Sub-Client User
2. **Steps**:
   - Navigate to the "Members" section.
   - Click on "Add New Member".
   - Fill in member details (name, contact, plan, etc.).
   - Submit to save the member.

### Assigning Trainer
1. **Access**: Sub-Client User
2. **Steps**:
   - Navigate to the "Assign Trainer" section.
   - Select a member and a trainer from the dropdowns.
   - Submit to assign the trainer to the member.

### Maintaining Member Fees
1. **Access**: Sub-Client User
2. **Steps**:
   - Navigate to the "Fees" section.
   - Select a member to view and update fees.
   - Update the fee details and submit to save changes.

## Installation and Setup

### Prerequisites
- .NET Core SDK 2.1
- SQL Server
- Visual Studio 2022

### Steps
1. **Clone the Repository**:
   ```bash
   git clone <repository-url>
   ```
2. **Open the Solution**:
   - Open the project solution in Visual Studio 2022.

3. **Update Database Connection String**:
   - In `appsettings.json`, update the connection string to point to your SQL Server instance.
4. **Build and Run the Project**:
   - Build the solution in Visual Studio.
   - Run the project to start the web application.

## Conclusion

The Gym Management Project provides a comprehensive solution for gym owners to manage their gym operations efficiently. With features tailored for both admin and sub-client users, the application ensures smooth management of batches, users, trainers, plans, and member details.

For any further queries or issues, please refer to the project documentation or contact the support team.
