using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DNWS
{
  class clientinfoPlugin : IPlugin
  {
    public clientinfoPlugin()
    {
    }

    public void PreProcessing(HTTPRequest request)
    {
    }
    public HTTPResponse GetResponse(HTTPRequest request)
    {
      HTTPResponse response = null;
      StringBuilder sb = new StringBuilder();

      String[] remoteendpoint = Regex.Split(request.getPropertyByKey("remoteendpoint"), ":");  // split to array

      sb.Append("<p>Client IP: " + remoteendpoint[0] + " </p>");
      sb.Append("<p>Client Port: " + remoteendpoint[1] + " </p>");
      sb.Append("<p>Browser Information: " + request.getPropertyByKey("user-agent") + " </p>");
      sb.Append("<p>Accept-Charset: " + request.getPropertyByKey("accept-language") + " </p>");
      sb.Append("<p>Accept-Encoding: " + request.getPropertyByKey("accept-encoding") + " </p>");
      sb.Append("</body></html>");

      response = new HTTPResponse(200);
      response.body = Encoding.UTF8.GetBytes(sb.ToString());
      return response;
    }

    public HTTPResponse PostProcessing(HTTPResponse response)
    {
      throw new NotImplementedException();
    }
  }
}