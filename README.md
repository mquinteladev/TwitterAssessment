
# TwitterAssessment

**Portal Application**

 - The UI application uses angular; please make sure before running the
   code the first time ***run npm install***.
 - The Angular application connects to an API in the backend; the API
   URL can be found in the environment file.
   
 - To retrieve continuous messages from the backed API, the angular is  
   using ***Signal-R***, highly recommended to run  the API first, as   
   resilience reconnection was not implemented as per time constraints.

 - Would you mind noticing the UI only shows the first 20 tweets as per 
   UI constraints, but there is a continuous data flow in the console   
   log (Warning View)?

 - See the Twitter details link does an API call in the backed; I am   
   aware the continuous flow brings similar data, but to do a   
   demonstration of not blocking report, I am doing API call and socket 
   connection simultaneously.

**API Application**

 - In the app setting, you can find the Twitter section, replace your
   desired values, and use current is valid.

 - Existing unit test integration was creating for the development
   porpoise; unit test coverage is not near 10% as per time constraints.
