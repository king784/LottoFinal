 <?php
$servername = "localhost";
$username = "id10269157_arpaadmin";
$password = "SALAsana19";
$dbname = "id10269157_arvontaesineet";

$itemName = $_POST["itemName"];
$itemID = $_POST["itemId"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}


//php my admin reference for deleting:
//DELETE FROM `Prizes` WHERE `Prizes`.`ID` = 6
//$query = "DELETE FROM Prizes WHERE I='$itemID'";
//$result = $mysqli->query($query)or die('{"Status":[{"Code":2}]}');
$sql = "DELETE FROM Prizes WHERE ItemID='$itemID'";
$result = $conn->query($sql);


// if ($result->num_rows > 0) {
//     // output data of each row
//     while($row = $result->fetch_assoc()) {
//         echo "id: " . $row["ID"]. " - Name: " . $row["ItemName"]. " " . $row["Description"]. "<br>";
//     }
// } else {
//     echo "0 results";
// }

$conn->close();
?> 