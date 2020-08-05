

## Base address for calling the api
Please use the following address for the api call. You can use it in your browser to get infromations or you can use it in postman to modify information. All of the example will be show bellow.

# ------------------------------------- #
http://imastuden.azurewebsites.net/api/
# ------------------------------------- #



## Changing a status of an element
To change the status of an element i suggest that you use Postman.
In Postman, change the request method to PUT, then in the body of the request make sure that raw is checked and the type of text is JSON. Inside the address, after the /{elements}/, insert the id of the element that you want to change   /{elements}/{the_id_of_the_element_that_you_want_to_change}. Put in the body of the request the thing that you want to change inside double quotes, in our case its the status, followed by a colon and inside another double quotes the status that you want it to be.
All of those informations should be inside curly brakets. Here is a small example:

# ----------------------------------------------- #
Methode: PUT   Address: http://imastuden.azurewebsites.net/api/{elements}/{the_id_of_the_element} 
Body:
{
    "status": "Intervention"
}
# ----------------------------------------------- #
* This will change the status of the element with the id that you inserted to Intervention.






# ----------ELEVATOR---------- #
## Check the status of an elevator
To check the status of an elevator you have to enter /elevators/{the_id_of_the_elevator}. You can do this directly in your browser or in Postman while changing the request type to GET. Here is an example: 
# ----------------------------------------------- #
http://imastuden.azurewebsites.net/api/elevators/1
# ----------------------------------------------- #
* This will return the elevator with the id 1 and his status

## Changing the status of an elevator
To change the status of an elevator, use the template for changing the status of an element. The body of the resquest will be the same except the status that you want to change it to. Here is an example of the address:
# ----------------------------------------------- #
http://imastuden.azurewebsites.net/api/elevators/1
replace the {elements} with : elevators
replace the {the_id_of_the_element} with : 1
# ----------------------------------------------- #
* This will change the status of the elevator with the id of 1 to Intervention.

## Get the list of elevator that are not in operation
To get the list of elevator that are not in operation you have to enter /inactiveelevators. You can do this directly in your browser or in Postman while changing the request type to GET. Here is an example:
# ----------------------------------------------- #
http://imastuden.azurewebsites.net/api/inactiveelevators
# ----------------------------------------------- #
* This will return the list of elevator that their status is not active






# ----------COLUMN---------- #
## Check the status of a column
To check the status of a column you have to enter /columns/{the_id_of_the_column}. You can do this directly in your browser or in Postman while changing the request type to GET.  Here is an example:
# ----------------------------------------------- #
http://imastuden.azurewebsites.net/api/columns/1
# ----------------------------------------------- #
* This will return the column with the id 1 and his status

## Changing the status of an column
To change the status of an column, use the template for changing the status of an element. The body of the resquest will be the same except the status that you want to change it to. Here is an example of the address:
# ----------------------------------------------- #
http://imastuden.azurewebsites.net/api/columns/1
replace the {elements} with : columns
replace the {the_id_of_the_element} with : 1
# ----------------------------------------------- #
* This will change the status of the column with the id of 1 to Intervention.






# ----------BATTERY---------- #
## Check the status of a battery
To check the status of a battery you have to enter /batteries/{the_id_of_the_battery}. You can do this directly in your browser or in Postman while changing the request type to GET.  Here is an example:
# ----------------------------------------------- #
http://imastuden.azurewebsites.net/api/batteries/1
# ----------------------------------------------- #
* This will return the battery with the id 1 and his status

## Changing the status of an battery
To change the status of an battery, use the template for changing the status of an element. The body of the resquest will be the same except the status that you want to change it to. Here is an example of the address:
# ----------------------------------------------- #
http://imastuden.azurewebsites.net/api/batteries/1
replace the {elements} with : batteries
replace the {the_id_of_the_element} with : 1
# ----------------------------------------------- #
* This will change the status of the battery with the id of 1 to Intervention.






# ----------BUILDINGS---------- #
## Get the list of building that have a battery/column/elevator that require intervention
To get the list of buildings that have at least one battery or column or elevator that his status is intervention you have to enter /buildings. You can do this directly in your browser or in Postman while changing the request type to GET. Here is an example:
# ----------------------------------------------- #
http://imastuden.azurewebsites.net/api/buildings
# ----------------------------------------------- #
* This will return the list of buildings that have at least one battery or column or elevator that his status is intervention






# ----------LEADS---------- #
## Retrieving a list of Leads created in the last 30 days who have not yet become customers.
To get this information you have to enter /leads. You can do this directly in your browser or in Postman while changing the request type to GET. Here is an example:
# ----------------------------------------------- #
http://imastuden.azurewebsites.net/api/leads
# ----------------------------------------------- #
