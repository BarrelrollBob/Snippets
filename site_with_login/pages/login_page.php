

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
    $wrongCredMessage = "";

    if ($_SERVER['REQUEST_METHOD'] == 'POST') {
        $email = $_POST['email'];
        $userPassword = $_POST['password'];

        $dbSession = new mysqli($servername, $username, $password, $database);

        $queryResult = $dbSession->query("SELECT Email, `Password` 
                                        FROM $table 
                                        WHERE Email = '$email' AND `Password` = '$userPassword'");
        
        if(mysqli_num_rows($queryResult) > 0) {
            echo "The user exists";
        }
        else {
            $wrongCredMessage = "The e-mail or password is wrong";
        }
    }

    ?>

            <a href = "front_page.html">Home</a>


        <div>    
            <form method = "POST" action = "<?php echo htmlspecialchars($_SERVER["PHP_SELF"]) ?>">
                <label for = "email">E-mail:</label><br>
                <input type = "email" id = "email" name = "email" value = "<?php echo isset($_POST["email"]) ? htmlspecialchars($_POST["email"]) : ""; ?>"><br>
                <label for = "password">Password:</label><br>
                <input type = "password" id = "password" name = "password"><br>
                <input type = "checkbox" name = "rememberLogin"><br>
                <input type = "submit" value = "Login" id = "submitButton"><br>
            </form>
            <p><?php echo $wrongCredMessage ?></p>
        </div>

    </body>
</html>
