

<!DOCTYPE html>

<html>
    <head>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel = "stylesheet" href = "styles/sign-up_page.css">
    </head>
    <body>

    <?php

    $servername = "localhost";
    $username = "root";
    $password = "";
    $database = "testDB";
    $table = "UserData";
    $emailErr = $nameErr = $passwordErr = "";

    $dbCreation = new mysqli($servername, $username);
    $dbCreation -> query("CREATE DATABASE IF NOT EXISTS $database");
    $dbCreation -> close();

    $tableCreation = new mysqli($servername, $username, $password, $database);
    $tableCreation -> query("CREATE TABLE IF NOT EXISTS $table (
        `UserID` int NOT NULL AUTO_INCREMENT,
        `Username` varchar(40),
        `Email` varchar(40) NOT NULL,
        `Password` varchar(40) NOT NULL,
        PRIMARY KEY(UserID)
        )
    ");
    $tableCreation -> close();  

    if ($_SERVER["REQUEST_METHOD"] == "POST") {
        
        $name = $_POST["name"];
        $email = $_POST["email"];
        $userPassword = $_POST["password"];

        if (empty($name) || empty($email)) {
            if (empty($name)) {
                $nameErr = "Name is required*";
            }
            if (empty($email)) {
                $emailErr = "Email is required*";
            }
            if (empty($userPassword)) {
                $passwordErr = "Password is required*";
            }
        }

        else {
            $connect = new mysqli($servername, $username, "", $database);
            $result = $connect -> query("SELECT Email FROM $table WHERE Email = '$email'");
            if(mysqli_num_rows($result) > 0) {
                echo("That user is already in the database");
            }
            else {
                $connect -> query("INSERT INTO $table (Username, Email, `Password`) 
                                VALUES ('$name', '$email', '$userPassword'); 
                                ");
            $connect -> close();
            echo("The user was inserted into the database");
            }
        }
    }

    ?>
        
        <a href = "front_page.html">Home</a>
        
        <div>
            <form method = "post" action = "<?php echo htmlspecialchars($_SERVER["PHP_SELF"]); ?>">
                <label for = "name">Name:</label><br>
                <input type = "text" id = "name" name = "name" value = "<?php echo isset($_POST["name"]) ? htmlspecialchars($_POST["name"]) : ''; ?>" ><br><span> <?php echo $nameErr ?></span><br>
                <label for = "email">E-mail:</label><br>
                <input type = "email" id = "email" name = "email" value = "<?php echo isset($_POST["email"]) ? htmlspecialchars($_POST["email"]) : ''; ?>"><br><span> <?php echo $emailErr ?></span><br>
                <label for = "password">Password:</label><br>
                <input type = "password" id = "password" name = "password"><br><span> <?php echo $passwordErr ?></span><br>
                <input type = "submit" id = "submitButton" name = "submit" value = "Sign up">
            </form>
        </div>
        
    </body>
</html>

<!--
    
    __FRONTPAGE__
    > Options to sign up or login VV

    __SIGNUP__
    > Two inputs in a form VV
    > Submit button VV
    > Query that creates a database if it doesn't exist VV
    > Create table if it doesn't exist VV
    > Table consists of e-mail and password (maybe name for whatever reason) VV
    > Inserts input into the table from the form (Problem was that I didn't know php variable values had to be quoted when inserting into mysql) VV
    > Checks if input is already in database VV
    > Because we're not annoying, if the insertion fails, keep the data in the inputs VV
    > Validate input (clean it up, check for correct formatting or invalid input, etc.) 
    > Give option to log in automatically
    > Use Regex to enforce allowed characters in username
    > Enforce password length
    > Fix error messages VV
    
    __LOGIN__
    > Two input fields and a submit button VV
    > Requires e-mail and password to log in VV
    > Log the user in if their credentials are correct VV
    > If not exists, echo "e-mail or password is wrong" VV
    > Maybe work with cookies so user can log in automatically or something
    

    __LANDINGPAGE__
    > Demonstrate different users somehow (does a name appear, does a colour change, can user input some text that is then stored in database? what?)
    > Logout option
    > User can pick their own background
    > User can write a personalized headline (max characters smth)
    > Username appears
    > Hovering over username displays userinfo (name and email) 


    __GENERAL__
    > Add some CSS to learn that VV
    > For now, have multiple pages. Later, try making a single page site (dom elements disappear / appear). How do I go about this?
    > Maybe make responsive
    > When you sign up, go straight to landing page

    Comment: 
    Remember that the code runs synchronously, and php tags can be put anywhere and still be in scope of other php tags
-->