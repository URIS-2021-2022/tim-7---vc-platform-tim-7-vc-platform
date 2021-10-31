# Comparative performance of Azure Functions and Azure App Service for VC platform application

Staring from 3.64 version you can run vc platform application on serverless environment as Azure Function. [How to run platform on Azure Functions](https://virtocommerce.com/docs/latest/techniques/how-to-run-platform-on-azure-functions/)

We decided to compare performances of both hosting models `Azure App Service` vs `Azure Functions` for vc platform and measure performance via performing load tests to see which hosting models gives the best results.

Please note that this experiment is not a load test. It shows the time and key difference between how VC platform behaves on different types of hosting models, "Platform as a Service" and "Serverless" respectively. 

We set up the two Azure environments, on the same Azure subscription in the same resource group.

#1 Azure App Service S1 (Standard) with monthly price 219$
- 1 Core
- 1.7 GB RAM
- 50 GB storage
- x3 instance (scale out)

#2 Azure Functions (Consumption tier) with monthly price 71$
- 1.6 GB RAM
- 30 M executions count

For both environments was used the one test `baseline` 
- Azure SQL S3 100 DTU
- Lucene search
- The vc platform as an application under test has the following sample data:
  - 200K catalog products
  - 1K categories
  - 100 active promotions
  - 3M prices
- All tests were conducted with Apache Jmeter
- Load profile  
  -  Max 100 users
  -  Ramp-up period 180 sec (add 1 new user each 1.8 sec)
  -  Test duration 180 sec

Each test has been performed 3 times, and then we counted the average value for each stage. 

# Performance test results


Let’s see the difference between average response time, the xAPI is hosted on Azure Functions almost in 3 times faster than hosted on `Azure App Service`.



Concluding Thoughts

Its fascinating to see how the different architectures impact the scaling and performance characteristics of the service. 
The platform application is run as Azure Function is showed almost a three times throughput advantage in comparison with 

