// Place this at: Models/ProjectData.cs
// Namespace below assumes your project is called "SajidPortfolio" — change if different.

namespace SajidPortfolio.Models
{
    public record ProjectItem(
        int Id,
        string Name,
        string Category,
        string Summary,
        string Overview,
        string Role,
        List<string> Highlights,
        string[] Tags,
        List<string> ImageFiles);

    public static class ProjectData
    {
        public static readonly List<ProjectItem> Projects = new()
        {
            // =========================================================
            // 1. EMPLOYEE ATTENDANCE SYSTEM
            // =========================================================

            new ProjectItem(
                1,
                "Employee Attendance System",
                "Internal tool — VasTek Solution",

                "ASP.NET Core MVC attendance management system for VasTek Solution, " +
                "with role-based access for employees and administrators.",

                "An internal attendance management system designed to replace manual " +
                "attendance tracking. Employees can log in to view their daily " +
                "check-in/check-out information and submit leave requests. " +
                "Administrators have additional modules for approving leave requests, " +
                "managing employee records, maintaining leave balances and generating " +
                "monthly attendance reports.",

                "Built the MVC controllers and views, authentication flow, and the " +
                "repository/service layers supporting Employees, Attendance, Leaves " +
                "and Leave Balances.",

                new List<string>
                {
                    "Cookie-based authentication with a 10-minute sliding session timeout",
                    "Custom middleware that restricts access to the office network only",
                    "Background hosted service for automatically checking out employees who forget to check out",
                    "Role-based navigation for employees and administrators",
                    "Employees can access Attendance and Leaves modules",
                    "Administrators can access Approve Leaves, Employees, Reports and Leave Balance",
                    "Daily attendance check-in and check-out tracking",
                    "Leave request management",
                    "Administrative leave approval workflow",
                    "Monthly attendance reporting",
                    "Excel export support for administrator reports"
                },

                new[]
                {
                    "ASP.NET Core MVC",
                    "C#",
                    "Cookie Authentication",
                    "Hosted Service",
                    "SQL Server",
                    "Bootstrap"
                },

                new List<string>
                {
                    "attendance-system_2.jpg",
                    "attendance-system3.jpg",
                    "attendance-system_4.jpg",
                    "attendance-system_5.jpg",
                    "attendance-system_6.jpg",
                    "attendance-system_7.jpg",
                    "attendance-system_8.jpg",
                    "attendance-system_9.jpg",
                    "attendance-system_10.jpg",
                    "attendance-system_11.jpg",
                    "attendance-system_12.jpg"
                }
            ),

            // =========================================================
            // 2. UNIVERSITY SERVER MONITOR
            // =========================================================

            new ProjectItem(
                2,
                "University Server Monitor",
                "Client work — Arul University",

                "WinForms desktop monitoring application that watches a Moodle " +
                "e-learning server and records downtime, uptime and restart alerts.",

                "A server monitoring tool developed for Arul University's Moodle " +
                "e-learning environment. The application periodically checks the " +
                "server status URL, determines whether the server is Up or Down, " +
                "parses uptime information and alerts administrators when the server " +
                "has been running beyond the configured restart threshold.",

                "Built the WinForms user interface and the complete monitoring, " +
                "alerting and SQL Server database logging functionality.",

                new List<string>
                {
                    "Checks the server URL every 5 minutes",
                    "Runs monitoring in the background so the UI remains responsive",
                    "Uses HttpClient for server status requests",
                    "Compares expected response lines to determine Up or Down status",
                    "Parses server uptime from the response",
                    "Raises a restart-due alert when uptime exceeds the configured threshold",
                    "Default restart threshold of 7 days",
                    "Logs server Down and Up incidents to SQL Server",
                    "Stores downtime duration for historical reporting",
                    "Falls back to a local error log when database logging fails"
                },

                new[]
                {
                    "C#",
                    "WinForms",
                    "HttpClient",
                    "SQL Server",
                    "Regex"
                },

                new List<string>
                {
                    "server-monitor.jpg"
                }
            ),

            // =========================================================
            // 3. AMS INTERVIEW PORTAL
            // =========================================================

            new ProjectItem(
                3,
                "AMS Interview Portal",
                "Client work — Arul University",

                "Applicant management and interview scheduling portal for " +
                "Arul University's admissions team.",

                "A centralized admissions portal designed to streamline candidate " +
                "tracking from application submission through interview scheduling. " +
                "The system brings applicant information and interview scheduling " +
                "into a single workflow backed by SQL Server.",

                "Worked on the ASP.NET Core backend and Angular frontend for the " +
                "interview scheduling workflow and applicant management functionality.",

                new List<string>
                {
                    "Applicant tracking from submission through interview",
                    "Candidate management workflow",
                    "Interview scheduling within the same application workflow",
                    "Centralized applicant information",
                    "SQL Server-backed applicant data",
                    "ASP.NET Core backend integration",
                    "Angular frontend workflow"
                },

                new[]
                {
                    "ASP.NET Core",
                    "Angular",
                    "SQL Server"
                },

                new List<string>
                {
                    "ams-interview-portal.jpg",
                    "ams-interview-portal1.jpg",
                    "ams-interview-portal2.jpg",
                    "ams-interview-portal3.jpg",
                    "ams-interview-portal4.jpg",
                    "ams-interview-portal5.jpg",
                    "ams-interview-portal6.jpg",
                    "ams-interview-portal7.jpg",
                    "ams-interview-portal8.jpg"
                }
            ),

            // =========================================================
            // 4. SSPT
            // =========================================================

            new ProjectItem(
                4,
                "SSPT",
                "Client work",

                "Internal business system built on a layered .NET architecture " +
                "with separate Contracts, Repository, Services, Security, Web API " +
                "and Web UI projects.",

                "An internal business system structured using a layered architecture. " +
                "Interfaces are maintained in dedicated Contracts projects while " +
                "Repository and Services implementations are separated into their " +
                "own projects. Security concerns are isolated into a dedicated " +
                "Security project, with Web API and Web UI maintained independently.",

                "Contributed to the repository and service layers and worked on " +
                "the Web UI.",

                new List<string>
                {
                    "Contracts and interfaces kept separate from implementations",
                    "Dedicated Repository layer",
                    "Dedicated Services layer",
                    "Dedicated Security project for authentication and authorization concerns",
                    "Separate Web API project",
                    "Independent Web UI project",
                    "API can be reused independently from the Web UI",
                    "SQL Server-backed data layer",
                    "Layered solution structure"
                },

                new[]
                {
                    ".NET Core",
                    "C#",
                    "SQL Server",
                    "Layered Architecture",
                    "Web API"
                },

                new List<string>
                {
                    "sspt.jpg",
                    "sspt1.jpg",
                    "sspt2.jpg",
                    "sspt3.jpg",
                    "sspt4.jpg",
                    "sspt5.jpg",
                    "sspt6.jpg",
                    "sspt7.jpg",
                    "sspt8.jpg"
                }
            ),

            // =========================================================
            // 5. WINFORMS DESKTOP APPLICATION
            // =========================================================

            new ProjectItem(
                5,
                "WinForms Desktop Application",
                "Client work",

                "Business-oriented Windows desktop application built with WinForms " +
                "and connected to a SQL Server backend.",

                "A Windows desktop application developed to support the client's " +
                "day-to-day business operations. The application provides a " +
                "desktop interface connected to a live SQL Server backend for " +
                "business data and operational workflows.",

                "Built the desktop user interface and the data access layer " +
                "connecting the application to SQL Server.",

                new List<string>
                {
                    "WinForms desktop interface",
                    "Business workflow support",
                    "SQL Server backend integration",
                    "Live database operations",
                    "Client-specific day-to-day business functionality",
                    "Dedicated data access layer"
                },

                new[]
                {
                    "WinForms",
                    "C#",
                    "SQL Server"
                },

                new List<string>
                {
                    "winforms-desktop-app.jpg",
                    "winforms-desktop-app1.jpg"
                }
            ),

            // =========================================================
            // 6. AI DOCUMENT REPOSITORY
            // =========================================================

            new ProjectItem(
                6,
                "AI Document Repository",
                "Personal / practice project",

                "WinForms document repository with category and department filtering, " +
                "expiry tracking, document versioning and approve/reject workflow.",

                "A desktop document management application designed to keep business " +
                "documents organized and track their lifecycle. Documents can be " +
                "filtered by category and department, searched by expiry date and " +
                "processed through an UnderReview, Approved, Rejected or Expired workflow.",

                "Built the WinForms grid, filtering functionality, document review " +
                "workflow, file upload functionality and document versioning.",

                new List<string>
                {
                    "Category-based document filtering",
                    "Department-based document filtering",
                    "Expiry date-range search",
                    "Automatic document status tracking",
                    "UnderReview document workflow",
                    "Approved document workflow",
                    "Rejected document workflow",
                    "Expired document tracking",
                    "File upload functionality",
                    "Document view and download",
                    "Approve, Reject and Delete actions",
                    "Document versioning"
                },

                new[]
                {
                    "C#",
                    "WinForms",
                    "SQL Server"
                },

                new List<string>
                {
                    "ai-document-repository.jpg"
                }
            ),

            // =========================================================
            // 7. NOVA SYSTEM
            // =========================================================

            new ProjectItem(
                7,
                "NOVA System",
                "Client work",

                "Business management system for enrolment, invoicing, vendor " +
                "payments and reporting with separate Invoicing and Payable modules.",

                "A multi-site business management system. The Invoicing side handles " +
                "child and customer enrolment, personal details, parent or carer " +
                "records, weekly attendance schedules and running payment summaries. " +
                "The Payable side manages vendor payment templates and expense payments.",

                "Worked on the business management functionality covering enrolment, " +
                "payment-related workflows and supporting application functionality.",

                new List<string>
                {
                    "Multi-site enrolment management",
                    "Multi-group enrolment",
                    "Child and customer records",
                    "Parent and carer information",
                    "Weekly attendance day and hours scheduling",
                    "Running invoicing summary",
                    "Paid, balance and overdue payment tracking",
                    "Payment summary split by payer",
                    "Reusable vendor payment templates",
                    "Payment template line items",
                    "Account and expense management",
                    "Account statement generation",
                    "Password-letter generation from enrolment records"
                },

                new[]
                {
                    "ASP.NET Core",
                    "C#",
                    "SQL Server",
                    "Bootstrap"
                },

                new List<string>
                {
                    "nova-system.jpg"
                }
            ),

            // =========================================================
            // 8. OFFSHORE TEAM ACCESS
            // =========================================================

            new ProjectItem(
                8,
                "OffShore Team Access (OSA)",
                "Personal / practice project",

                "Centralized ticket and access-request management system for offshore " +
                "team coordination, with role-based login and ticket lifecycle tracking.",

                "OSA is a ticketing and access-request platform designed for offshore " +
                "team coordination. Users can create access-request and change-request " +
                "tickets against a system and university or client. Administrators can " +
                "track tickets through a complete lifecycle including Open, Pending, " +
                "Assigned, On-Hold, Closed and Canceled states. Each ticket also has " +
                "a threaded notes panel for collaboration between the requester and " +
                "assigned team member.",

                "Designed and built the solution end to end, including the layered " +
                "architecture, ticket dashboard, ticket creation flow, master-data " +
                "dropdowns and ticket notes/comments system.",

                new List<string>
                {
                    "Layered architecture with Contracts, Repositories and Services separated from the Web UI",
                    "Role-based authentication",
                    "Dedicated ticket dashboard",
                    "Live ticket status counters",
                    "Total ticket counter",
                    "Open ticket tracking",
                    "Pending ticket tracking",
                    "Assigned ticket tracking",
                    "On-Hold ticket tracking",
                    "Closed ticket tracking",
                    "Canceled ticket tracking",
                    "Ticket creation modal",
                    "Dependent Ticket Type, System and University dropdowns",
                    "Date-range selection using Flatpickr",
                    "Ticket-specific threaded notes",
                    "Chat-style communication between requester and assigned handler",
                    "AJAX-based notes loading",
                    "Dedicated sign-out confirmation flow"
                },

                new[]
                {
                    "ASP.NET Core MVC",
                    "Entity Framework Core",
                    "SQL Server",
                    "jQuery",
                    "Flatpickr"
                },

                new List<string>
                {
                    "osa-login.jpg",
                    "osa-dashboard.jpg",
                    //"osa-notes-modal.jpg",
                    "osa-notes-modal1.jpg",
                    "osa-dashboard1.jpg",
                    "osa-dashboard2.jpg"
                }
            ),

            // =========================================================
            // 9. MOBILESTORE
            // =========================================================

            new ProjectItem(
                9,
                "MobileStore",
                "Personal / practice project",

                "ASP.NET Core MVC e-commerce platform for a mobile phone retailer " +
                "with customer shopping, authentication, product management, " +
                "reviews, cart, checkout, orders and a dedicated admin panel.",

                "MobileStore is a complete e-commerce application built for a mobile " +
                "phone retailer. Customers can register and verify their accounts, " +
                "sign in using email/password or Google authentication, browse and " +
                "search products, filter products by category and price, view product " +
                "details and images, manage their shopping cart, place orders, manage " +
                "their profiles and submit product reviews. The application also " +
                "includes email verification, OTP verification, password recovery " +
                "and password management. A dedicated admin area provides management " +
                "of products, categories, customers, reviews, stock and orders.",

                "Designed and developed the MVC controllers, Razor views and " +
                "repository/data-access layer across the Account, Admin, Cart, Home, " +
                "Order and Product areas. Implemented customer authentication, Google " +
                "login, email verification, OTP/password recovery, product browsing " +
                "and filtering, shopping cart functionality, reviews and ratings, " +
                "product image management and admin-side catalog, customer and " +
                "order management.",

                new List<string>
                {
                    "Customer storefront for browsing mobile products",
                    "Product search by name, brand and description",
                    "Category-based product filtering",
                    "Price-range product filtering",
                    "Price ascending and descending sorting",
                    "Newest product sorting",
                    "Detailed product pages",
                    "Product descriptions and pricing",
                    "Sale prices and discounts",
                    "Product stock information",
                    "Multiple product images",
                    "Shopping cart with add, update and remove functionality",
                    "Checkout and order placement",
                    "Customer registration and login",
                    "Customer logout and session management",
                    "Customer profile management",
                    "Email account verification",
                    "Verification token expiry support",
                    "OTP generation and verification",
                    "OTP storage and expiry handling",
                    "One-time OTP usage",
                    "Google authentication",
                    "Google verified-user handling",
                    "Forgot password functionality",
                    "Secure password reset tokens",
                    "Change password functionality",
                    "Google-user password setup",
                    "Remember Me persistent login option",
                    "Product reviews and ratings",
                    "Customer review submission",
                    "Admin review approval",
                    "Admin review unapproval",
                    "Admin review deletion",
                    "Automatic average rating calculation",
                    "Automatic review count calculation",
                    "Featured product listings",
                    "Best-selling product listings",
                    "New arrivals listing",
                    "Related products by category",
                    "Additional product image management",
                    "Product stock management",
                    "Low-stock product tracking",
                    "Admin product management",
                    "Admin category management",
                    "Admin customer management",
                    "Admin review management",
                    "Admin order management",
                    "Product active/inactive management",
                    "Category active/inactive management",
                    "Customer account active/inactive management",
                    "Repository-based data access",
                    "Separate repositories for Users, Products, Categories, Reviews and OTPs",
                    "Parameterized Dapper database queries",
                    "MVC separation between controllers, views, models and repositories"
                },

                new[]
                {
                    "ASP.NET Core MVC",
                    "C#",
                    "Dapper",
                    "SQL",
                    "Bootstrap",
                    "Razor Views",
                    "Google Authentication",
                    "BCrypt"
                },

                new List<string>
                {
                    "mobilestore-home.jpg",
                    "mobilestore1.jpg",
                    "mobilestore2.jpg",
                    "mobilestore3.jpg",
                    "mobilestore4.jpg",
                    "mobilestore5.jpg",
                    "mobilestore6.jpg",
                    "mobilestore7.jpg",
                    "mobilestore8.jpg",
                    "mobilestore9.jpg",
                    "mobilestore10.jpg",
                    "mobilestore11.jpg",
                    "mobilestore12.jpg",
                    "mobilestore13.jpg",
                    "mobilestore14.jpg",
                    "mobilestore15.jpg",
                    "mobilestore16.jpg",
                    "mobilestore17.jpg",
                    "mobilestore18.jpg",
                    "mobilestore19.jpg"
                }
            ),

            // =========================================================
            // 10. POSTCODE WRAPPER API
            // =========================================================

            new ProjectItem(
                10,
                "Postcode Wrapper API",
                "Personal / practice project",

                "Lightweight ASP.NET Core Web API that validates and wraps a " +
                "third-party UK postcode lookup service with request rate limiting.",

                "A focused backend microservice that sits in front of a third-party " +
                "postcode lookup provider. The API validates incoming UK postcodes " +
                "before making an upstream request, then returns the provider result " +
                "as clean JSON. Rate limiting is applied to prevent a single client " +
                "from flooding the upstream service.",

                "Built the API end to end, including the controller, request validation, " +
                "service layer, upstream provider integration and rate-limiting policy.",

                new List<string>
                {
                    "UK postcode format validation",
                    "Regex-based postcode validation",
                    "Length validation before upstream requests",
                    "Invalid input rejected before calling the third-party provider",
                    "Fixed-window rate limiting",
                    "ASP.NET Core built-in RateLimiting middleware",
                    "Service-layer abstraction through IPostcoderService",
                    "Upstream provider can be replaced without changing the controller",
                    "Consistent JSON responses for invalid postcodes",
                    "Consistent JSON responses for missing postcode input",
                    "Clean REST API structure"
                },

                new[]
                {
                    "ASP.NET Core Web API",
                    "C#",
                    "Rate Limiting",
                    "REST"
                },

                new List<string>
                {
                    "postcode-api-swagger.jpg",
                    "postcode-api-swagger1.jpg"
                }
            )
        };
    }
}