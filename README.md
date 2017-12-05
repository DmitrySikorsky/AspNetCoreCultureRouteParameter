# ASP.NET Core Culture Route Parameter
This is a demo web application for the
“[ASP.NET Core Culture Route Parameter](http://sikorsky.pro/en/blog/aspnet-core-culture-route-parameter)”
post on the [Dmitry Sikorsky’s blog](http://sikorsky.pro/en/blog).
It shows how to specify culture as the URL segment using the route parameter by overriding the
`DetermineProviderCultureResult` method of the `RequestCultureProvider` class.

The result looks like this:
![ASP.NET Core Culture Route Parameter](http://sikorsky.pro/images/github/aspnetcore-culture-route-parameter/result.png)
*ASP.NET Core Culture Route Parameter*

## Using the Application

1. Run the application.
2. Change the culture segment in the URL.
3. Check the current culture and the UI culture in the view.