

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
