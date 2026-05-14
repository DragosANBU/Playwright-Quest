# **Test Plan - Automation Exercise**
## **Goal**
 ### The goal of this test plan is to test the most important funcionalities of the [Automation Exercise](https://automationexercise.com/) website and make sure the main user scenarios work correctly.
 ### The website is an online shop, so i think the most important test are realatead to:
-	registration and login
-	browsing products
-	adding products to cart
-	checkout
-	contact us form
### These are the core funcionalities of the application, without these working properly the users cannot complete the flow.

## **Scenarios worth testing**
### **1. User registration**
### Scenarios:
- Register with correct email and password
- Register with an already existing email
- Register with empty fields
- Register with invalid email format
### Why it is worth testing: 
If registration does not work, new users cannot use the website.

### **2. Login and Logout**
### Scenarios:
- Login with correct email and password
- Login with wrong email and/or password
- Login with empty fields
- Logout after login
### Why it is worth testing: 
Wrong login behavior can make the site unusable and confuse the user.

### **3. Products page**
### Scenarios:
- Open the products page
- View product details
- Verify that products have name, price and image
### Why it is worth testing:
The user needs correct information about a product before buying it. 

### **4. Search functionality**
### Scenarios:
- Search for an existing product
- Search for a prduct that does no exist
- Search using special characters
### Why it is worth testing:
Search helps users find products faster. If it doesn't work, the user experience is worse.

### **5. Cart functionality**
### Scenarios:
- Add a product to cart
- Add multiple products to cart
- Remove a product from cart
- Change quantity of a product
### Why it is worth testing:
If the cart doesn't work properly, users may not be able to buy products, may recive wrong prices or recive wrong number of products.

### **6. Check out**
### Scenarios:
- Checkout with logged in user
- Checkout after new account registration
- Verify delivery and billing details
- Place order successfully
- Checkout with empty cart
### Why it is worth testing:
This is the most important business flow of the website. If the chekout fails, the user can't complete the purchase.

### **7. Contact us form**
### Scenarios:
- Submit with valid data
- Submit with empty fields
- Submit with invalid email
- Upload file
### Why it is worth testing:
Contacts us forms are used for communication and should show errors for invalid inputs.

## **Additional scenarios not included in existing test cases**
- Add the same product multiple times in cart
- Invalid card details at checkout
- Very long input for user/password/forms
- Very short input for password
- Staying logged in and keeping cart after refreshing
- Remebering products in cart after new account registration

## **Improvements for the application**
- Improve hover animation on product card
- Add Sorting functionality in Products page
- Add Favorites/Wishlists feature to improve user engagement
- Improve minimum/maximum input constraints for user and password fields