 <?php
$servername = "localhost";
$username = "id10269157_arpaadmin";
$password = "SALAsana19";
$dbname = "id10269157_arvontaesineet";

$itemName = $_POST["itemName"];
$itemDesc = $_POST["itemDesc"];
$quantity = $_POST["quantity"];
$itemID =$_POST['itemId']

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

for($x = 0; $x < $quantity; $x++)
{
    $query = "SELECT *FROM  Prizes WHERE ItemName='$itemName'"
    $sql = "DELETE FROM Prizes WHERE ItemName='$itemName'";
    $result = $conn->query($sql);
}

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