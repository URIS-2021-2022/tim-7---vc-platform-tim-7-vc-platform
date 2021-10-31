# Pricing module

Managing prices is the scenario that results appearing different prices for one product in different conditions or for different users. 

## Overview

*Describe main entities definitions, navigation, indexation, etc.*

## Relations

Type |Relations
---|--- 
Price lists | (many) price lists <-> (one) currency; (one) price list <-> (many) price list assignments; 
Price list assignments | (many) price list assignments <-> (one) catalog; (many) price list assignment <-> (one) price list;
Prices | (many) prices <-> (one) price list; (many) prices <-> (one) product;
Price lines | (many) price lines <-> (one) price list; (one) price line <-> (one) sale price; (one) price line <-> (one) list price; 

> Price list can have only one currency, it can be changed in Price list details.

> Price list can have one or many Price list assignments. Each Price list assignment can be related only to one catalog. 
> The product items selected in Price list should be from the catalog selected in Price list assignment.

> Product can have many prices. You can add product price from Price list (Product items widget) or from Product details (Price widget)
> If you add price from Product details, for this need select price list, make sure that this price list has price list assignment with 
> the corresponding Catalog of this product.

> Product can have different price lines. Each price line has regular and sales prices. Each price line related to  Price list. 
> Product can have different sales related to one price line for different quantity.


## Atomic functions and scenarios

### How to create Price list

1.	Open Pricing module
2.	Open Price list tab
3.	Click Add button
4.	Fill Name(required) field
5.	Select Currency
6.	Fill Description(not required) field
7.	Click Create
8.	System will reopen saved Price list
9.	Click on Assignments widget
10.	Add Price list assignment
11.	Click Save on manage Price list blade

### How to delete Price list

1.	Open Pricing module
2.	Open Price list tab
3.	Click on needed price list with RMB or open context menu
4.	Click Delete

### How to delete few Price lists

1.	Open Pricing module
2.	Open price list tab
3.	Select needed price lists 
4.	Click Delete in the header of the blade

### How to add Price list assignment to Price list

1.	Open Pricing module
2.	Open Price list tab
3.	Click on needed price list 
4.	Click on Assignments widget
5.	Click Add button
6.	System opens New price list assignments blade
7.	Price list field is preselected with price list from where you create assignment
8.	Fill other necessary fields 
9.	Click Create button
10.	Save Price list

### How to create Price list assignment

1.	Open Pricing module
2.	Open Price list assignments tab
3.	Click Add button 
4.	System opens New price list assignment blade
5.	Fill Assignment name (required)
6.	Select Catalog (required)
7.	Select Price list (required)
8.	Fill Priority, Description 
9.	Set Enable and Expiration date
10.	Set conditions for shoppers 
11.	Click Create

### How to edit Price list assignments

1.	Open Pricing module
2.	Open Price list assignments tab
3.	Click on needed price list assignment
4.	System opens Edit blade
5.	Change data in needed fields
6.	Click Save

### How to make priority for price list assignments

1.	Open Pricing module
2.	Open Price list assignments tab
3.	Open price list assignment to edit
4.	Fill Priority field

> Notice that the Product price related to price list assignments with the Higher value will be used first.

### How to change Eligible shoppers for price list assignments

1.	Open Pricing module
2.	Open Price list assignments tab
3.	Open price list assignment to edit
4.	Go to Eligible shoppers block
5.	Choose if conditions are required
6.	Add conditions

> This rules set availability of prices  in this price list related to price list catalog for shoppers. 

### How to set timeframes for price list assignment

1.	Open Pricing module
2.	Open Price list assignments tab
3.	Open price list assignment to edit
4.	Set value for Enable date
5.	Set value for Expiration date
6.	Save

> This timeframes set availability for all prices in Price list related to catalog from this price list assignment. 

### How to add price for product

1.	Open Pricing module
2.	Open Price list tab
3.	Click on needed price list 
4.	Click on Prices widget
5.	Click Add button
6.	System opens Select Product to manage Prices blade
7.	Click Add button 
8.	Select needed products 

> You should select product from catalog which was selected in price list assignment.

### How to add new currency

1.	Open Pricing module
2.	Open Price list tab
3.	Click on needed price list 
4.	Click on edit (pencil) button near Currency field
5.	System opens Currencies blade
6.	Click on Add button
7.	System opens New currency blade
8.	Fill needed fields
9.	Click Create

> Notice that this currency will be available for all price lists and Stores.

### How to set timeframes for price

1.	Open Pricing module
2.	Open Price list tab
3.	Click on needed price list 
4.	Click on Prices widget
5.	System opens blade with product list
6.	Click on needed Product
7.	System opens Edit prices blade for this product
8.	Open Burger menu and select Valid from Valid to
9.	Close menu
10.	Add values into Valid from and Valid to fields is If needed
11.	Save

> This value will be implemented only for selected price.
