
    <h1>Food Rescue Project</h1>

    <h2>Overview</h2>
    <p>The <strong>Food Rescue</strong> project is a comprehensive system designed to manage food donations and requests. The application connects restaurants, NGOs, and administrators to facilitate the rescue and redistribution of food to those in need. This project includes features for user authentication, food management, and a user-friendly interface for various stakeholders.</p>

    <h2>Features</h2>
    <ul>
        <li><strong>User Authentication:</strong> Login and registration for different user roles (Administrators, NGOs, Restaurants).</li>
        <li><strong>Admin Management:</strong> Admin dashboard for overseeing food donations, managing requests, and handling inquiries.</li>
        <li><strong>NGO Interface:</strong> Dashboard for NGOs to manage food requests. Forms for submitting food requests and viewing available donations.</li>
        <li><strong>Restaurant Interface:</strong> Dashboard for restaurants to manage and enter food donations.</li>
        <li><strong>Food Management:</strong> Enter and manage food details and entries. Track food requests and match them with available donations.</li>
        <li><strong>Database Connectivity:</strong> Connection management for storing and retrieving data related to food donations, user information, and requests.</li>
    </ul>

    <h2>Project Structure</h2>
    <ul>
        <li><strong>AdminEnquiry.*, Admin_Dashboard.*, Admin_home.*:</strong> Files for the admin interface including dashboards and inquiry management.</li>
        <li><strong>EnterFood.*, FoodDetails.*, FoodEntry.*, Food_data.*:</strong> Files related to entering, viewing, and managing food data.</li>
        <li><strong>FoodReqByNGO.*, FoodRequestsAdmin.*:</strong> Files for handling food requests by NGOs and administrative management of these requests.</li>
        <li><strong>Login_Form.*, Register_Form.*, MY_CONNECTION.vb, Module1.vb:</strong> Files for user authentication and database connections.</li>
        <li><strong>NGOEnquiry.*, NGO_Home.*, ngodashboard.*, reqdetngo.*:</strong> Files for NGO-related functionality including dashboards and request details.</li>
        <li><strong>RequestFormNGO.*, RestDashboard.*, Restaurant_Home.*:</strong> Files for restaurant management and NGO request forms.</li>
        <li><strong>ViewFoodReq.*, edtuserdetail.*, mngfooddonor.*, universal.vb:</strong> Files for viewing requests, editing user details, and managing food donors.</li>
    </ul>

    <h2>Installation</h2>
    <ol>
        <li>Clone the repository:
            <pre><code>git clone https://github.com/yourusername/food-rescue.git</code></pre>
        </li>
        <li>Open the project in Visual Studio.</li>
        <li>Restore the required packages and dependencies.</li>
        <li>Build and run the project.</li>
    </ol>

    <h2>Usage</h2>
    <ol>
        <li><strong>Run the application</strong> in Visual Studio.</li>
        <li><strong>Register</strong> as a new user or <strong>login</strong> if you already have an account.</li>
        <li><strong>Navigate</strong> to the respective dashboards (Admin, NGO, Restaurant) to manage food donations and requests.</li>
    </ol>

    <h2>Contributing</h2>
    <ol>
        <li>Fork the repository.</li>
        <li>Create a new branch (<code>git checkout -b feature/your-feature</code>).</li>
        <li>Commit your changes (<code>git commit -am 'Add new feature'</code>).</li>
        <li>Push to the branch (<code>git push origin feature/your-feature</code>).</li>
        <li>Create a new Pull Request.</li>
    </ol>

    <h2>License</h2>
    <p>This project is licensed under the MIT License - see the <a href="LICENSE">LICENSE</a> file for details.</p>

    <h2>Acknowledgements</h2>
    <ul>
        <li><a href="https://visualstudio.microsoft.com/">Visual Studio</a> for the development environment.</li>
        <li><a href="https://github.com/">GitHub</a> for version control and collaboration.</li>
    </ul>

