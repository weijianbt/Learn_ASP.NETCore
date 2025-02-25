# ASP.NET Core MVC Tutorial Notes

## Key Concepts

## 1. ASP.NET Core Boilerplate Code
ASP.NET Core provides built-in scaffolding for commonly used components, including:
- **Layouts** for consistent UI structure.
- **Authentication and Authorization** for user login and security.
- **DbContext and Entity Framework (EF Core)** for database interaction.

## 2. Model-View-Controller (MVC)
ASP.NET Core follows the **MVC** design pattern to separate concerns:

- **Model**  
  Represents the application’s data and business logic.  
  - Defines data structures using C# classes.
  - Uses **Entity Framework Core (EF Core)** for database interactions.
  - Includes **data annotations** for validation.

- **View**  
  Handles UI presentation.  
  - Uses **Razor syntax** (`.cshtml` files) to generate dynamic HTML.
  - Binds data from the **Model**.
  - Supports **Tag Helpers** (e.g., `asp-for`, `asp-action`) to simplify form handling.

- **Controller**  
  Manages user requests and application logic.  
  - Processes HTTP requests.
  - Calls the **Model** to retrieve or modify data.
  - Passes data to the **View** for rendering.

## 3. Data Validation

### Client-Side Validation
- **Handled by:** JavaScript (`jquery.validate.min.js`, `jquery.validate.unobtrusive.min.js`).
- **Enabled via:**  
  - Adding `asp-validation-for` attributes in the view.
  - Including `_ValidationScriptsPartial.cshtml` in the layout or view.
- **Behavior:**  
  - Runs in the browser before submitting the form.
  - Provides instant feedback without a server round trip.
  - Requires JavaScript to be enabled.

### Server-Side Validation
- **Handled by:** Model validation in the controller.
- **Enabled via:**  
  - `ModelState.IsValid` check in the controller.
  - Data annotations in the **Model** (e.g., `[Required]`, `[StringLength(60, MinimumLength = 3)]`).
- **Behavior:**  
  - Runs even if JavaScript is disabled.
  - Ensures validation is enforced regardless of client-side manipulations.

## 4. Entity Framework Core (EF Core)

- **Role:** Acts as an Object-Relational Mapper (ORM) to interact with the database.
- **Key Features:**
  - Defines database models using **C# classes**.
  - Uses **DbContext** to manage database operations.
  - Supports **migrations** to apply schema changes.

### Database Migrations Workflow
1. **After modifying the Model (`Movie.cs`)**, create a new migration through "Add-migration <migrationName> -Context <DbContext>" in power shell terminal.
2. **Apply the changes to the database through "Update-Database -Context <DbContext>"
3. **If there's issue with the migration, remove the migration through "Remove-Migration -Context <ContextClass>"

# 5. Additional Concept

## Anti-Forgery Token (CSRF Protection)

### Purpose
- Prevents **Cross-Site Request Forgery (CSRF)** attacks.

### What is a CSRF Attack?
- A hacker **tricks a logged-in user** into unknowingly submitting a request (e.g., modifying data).
- Example: A fake webpage mimics a real form and submits unauthorized requests on behalf of the user.

### How It Works
1. **Web Forms & POST Requests**  
   - Data is sent between the **client (browser)** and **server**.
   
2. **Attack Scenario**  
   - A fake webpage **imitates** a real form and sends malicious requests.
   
### Prevention Mechanism
- `@Html.AntiForgeryToken()` **generates a unique token**.
- The token is **stored in two places**:
  - A **hidden form field** (`_RequestVerificationToken`).
  - A **user cookie**.

### Validation Process
1. **On form submission**, MVC **compares** both token values.
2. If they **don’t match**, the request is **blocked**.

### Implementation in MVC
- Add the **anti-forgery token** in forms:
  ```html
  @Html.AntiForgeryToken()

# Resources:
1. https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-9.0&tabs=visual-studio
