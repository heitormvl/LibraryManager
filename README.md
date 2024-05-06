#### Introduction

The Library Management System is a simple console application that allows users to manage book and user data within a library. This includes adding, removing, borrowing, and returning books, as well as adding and removing users. Users can also search for books and other users by various attributes.

#### Features

-   **Manage Books:** Add, remove, and search for books.
-   **Manage Users:** Add, remove, and search for users.
-   **Borrow and Return Books:** Manage the borrowing and returning of books to and from users.

#### How to Run the Program

1. **Prerequisites:**

    - Ensure you have [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.

2. **Download the Source Code:**

    - Clone the repository or download the source code to your local machine.

    ```bash
    git clone <url-of-your-repository>
    cd LibraryManagementSystem
    ```

3. **Build the Application:**

    - Open your terminal or command prompt and navigate to the project directory.
    - Build the application using the following command:

    ```bash
    dotnet build
    ```

4. **Run the Application:**

    - After building the project, you can run it using:

    ```bash
    dotnet run
    ```

#### Usage Instructions

-   **Navigating the Menu:**

    -   After starting the application, you will be greeted with a menu of options ranging from 1 to 9.
    -   Enter the number corresponding to the action you wish to perform and press enter.
    -   Follow the on-screen prompts to complete each action.

-   **Borrowing a Book:**

    -   Select option `1` from the menu and follow the prompts to enter the user ID and the book ID.

-   **Returning a Book:**

    -   Select option `2` and provide the necessary user and book ID as prompted.

-   **Adding/Removing Books or Users:**

    -   Choose the respective option from the menu to add or remove books or users, and provide the required information as prompted.

-   **Searching:**
    -   Use option `7` to search for books and `8` for users. You can search by names for users and titles or IDs for books.

#### Support

For support, contact [heitormvl12@gmail.com](mailto:heitormvl12@gmail.com) or open an issue in the GitHub repository if applicable.

#### Contributing

Contributions to the Library Management System are welcome. Please fork the repository and submit a pull request with your enhancements.

#### License

This project is licensed under the MIT License - see the [LICENSE file](https://github.com/heitormvl/LibraryManager/LICENSE) for details.
