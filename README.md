# Food Rescue Project

## Overview

The **Food Rescue** project is a comprehensive system designed to manage food donations and requests. The application connects restaurants, NGOs, and administrators to facilitate the rescue and redistribution of food to those in need. This project includes features for user authentication, food management, and a user-friendly interface for various stakeholders.

## Features

<ul>
    <li><strong>User Authentication:</strong> Login and registration for different user roles (Administrators, NGOs, Restaurants).</li>
    <li><strong>Admin Management:</strong> Admin dashboard for overseeing food donations, managing requests, and handling inquiries.</li>
    <li><strong>NGO Interface:</strong> Dashboard for NGOs to manage food requests. Forms for submitting food requests and viewing available donations.</li>
    <li><strong>Restaurant Interface:</strong> Dashboard for restaurants to manage and enter food donations.</li>
    <li><strong>Food Management:</strong> Enter and manage food details and entries. Track food requests and match them with available donations.</li>
    <li><strong>Database Connectivity:</strong> Connection management for storing and retrieving data related to food donations, user information, and requests.</li>
</ul>

## Project Structure

<ul>
    <li><strong>AdminEnquiry.*, Admin_Dashboard.*, Admin_home.*:</strong> Files for the admin interface including dashboards and inquiry management.</li>
    <li><strong>EnterFood.*, FoodDetails.*, FoodEntry.*, Food_data.*:</strong> Files related to entering, viewing, and managing food data.</li>
    <li><strong>FoodReqByNGO.*, FoodRequestsAdmin.*:</strong> Files for handling food requests by NGOs and administrative management of these requests.</li>
    <li><strong>Login_Form.*, Register_Form.*, MY_CONNECTION.vb, Module1.vb:</strong> Files for user authentication and database connections.</li>
    <li><strong>NGOEnquiry.*, NGO_Home.*, ngodashboard.*, reqdetngo.*:</strong> Files for NGO-related functionality including dashboards and request details.</li>
    <li><strong>RequestFormNGO.*, RestDashboard.*, Restaurant_Home.*:</strong> Files for restaurant management and NGO request forms.</li>
    <li><strong>ViewFoodReq.*, edtuserdetail.*, mngfooddonor.*, universal.vb:</strong> Files for viewing requests, editing user details, and managing food donors.</li>
</ul>

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/food-rescue.git
    ```
2. Open the project in Visual Studio.
3. Restore the required packages and dependencies.
4. Build and run the project.

## Usage

1. **Run the application** in Visual Studio.
2. **Register** as a new user or **login** if you already have an account.
3. **Navigate** to the respective dashboards (Admin, NGO, Restaurant) to manage food donations and requests.

## Contributing

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature/your-feature`).
5. Create a new Pull Request.


## Acknowledgements

- [Visual Studio](https://visualstudio.microsoft.com/) for the development environment.
- [GitHub](https://github.com/) for version control and collaboration.
