/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Models;

import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URI;
import java.net.URISyntaxException;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import org.apache.http.client.methods.CloseableHttpResponse;
import org.apache.http.client.methods.HttpDelete;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.client.methods.HttpPut;
import org.apache.http.client.methods.HttpUriRequest;
import org.apache.http.client.methods.RequestBuilder;
import org.apache.http.client.utils.URIBuilder;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.CloseableHttpClient;
import org.apache.http.impl.client.HttpClients;
import org.apache.http.util.EntityUtils;

/**
 *
 * @author XD
 */
public class Peticiones {
     public String getAll(String uri) {
        String salida = null;
        try {
            CloseableHttpClient httpClient = Client.getHttpClient();
            
            HttpGet httpGet = new HttpGet(uri);
            CloseableHttpResponse httpResponse = httpClient.execute(httpGet);
            
            salida = EntityUtils.toString(httpResponse.getEntity());
            
        } catch (IOException ex) {
            System.out.println(ex);
        }
        
        return salida;
    }
    
    public String get(String uri) {
        String salida = null;
        try {
            CloseableHttpClient httpClient = Client.getHttpClient();
            
            HttpGet httpGet = new HttpGet(uri);
            CloseableHttpResponse httpResponse = httpClient.execute(httpGet);
            
            salida = EntityUtils.toString(httpResponse.getEntity());
            
        } catch (IOException ex) {
            System.out.println(ex);
        }
        
        return salida;
    }
    
    
    public String getByRol(String uri, String nombre) {
        String salida = null;
        try {
            CloseableHttpClient httpClient = Client.getHttpClient();
            
            URI uriParam = new URIBuilder(uri)
                    .addParameter("Nombre", nombre)
                    .build();
            
            HttpGet httpGet = new HttpGet(uriParam);
            
            CloseableHttpResponse httpResponse = httpClient.execute(httpGet);
            
            int status = httpResponse.getStatusLine().getStatusCode();
            
            if (status >= 200 && status < 300) {
                salida = EntityUtils.toString(httpResponse.getEntity());
            }
            
        } catch (URISyntaxException ex) {
            System.out.println(ex);
        } catch (IOException ex) {
            System.out.println(ex);
        }
        
        return salida;
    }
    
    public String post(String uri, String json) {
        String salida = null;
        try {
            CloseableHttpClient httpClient = Client.getHttpClient();
            HttpPost httpPost = new HttpPost(uri);
            
            StringEntity entity = new StringEntity(json, "UTF-8");
            httpPost.setEntity(entity);
            
            CloseableHttpResponse httpResponse = httpClient.execute(httpPost);
            
            salida = EntityUtils.toString(httpResponse.getEntity());
         
            
        } catch (IOException ex) {
            System.out.println(ex);
        }
        return salida;
    }
     public String getByPost(String uri,String json) {
        String salida = null;
        try {
            CloseableHttpClient httpClient = Client.getHttpClient();            
            HttpPost httpPost = new HttpPost(uri);
            
            StringEntity entity = new StringEntity(json, "UTF-8");
            httpPost.setEntity(entity);
            //CloseableHttpResponse httpResponse = httpClient.execute(httpGet);
            CloseableHttpResponse httpResponse = httpClient.execute(httpPost);
            
            salida = EntityUtils.toString(httpResponse.getEntity());
         
            //salida = EntityUtils.toString(httpResponse.getEntity());
            System.out.println("");
        } catch (IOException ex) {
            System.out.println(ex);
        }
        
        return salida;
    }
    public boolean put(String uri,String json) {
        boolean salida = false;
        try {
            CloseableHttpClient httpClient = Client.getHttpClient();
            
            HttpPut httpPut = new HttpPut(uri);
            
            StringEntity entity = new StringEntity(json, "UTF-8");
            httpPut.setEntity(entity);
            
            CloseableHttpResponse httpResponse = httpClient.execute(httpPut);
            
            int status = httpResponse.getStatusLine().getStatusCode();
            
            if (status >= 200 && status < 300) {
                salida = true;
            } else {
                salida = false;
            }
            
        } catch (IOException ex) { 
            System.out.println(ex);
        }
        
        return salida;
    }
    
    public boolean delete(String uri, String number) {
        boolean salida = false;
        try {
            CloseableHttpClient httpClient = Client.getHttpClient();
            
            HttpDelete httpDelete = new HttpDelete(uri + number);
            
            CloseableHttpResponse httpResponse = httpClient.execute(httpDelete);
            
            int status = httpResponse.getStatusLine().getStatusCode();
            
            if (status >= 200 && status < 300) {
                salida = true;
            } else {
                salida = false;
            }
            
        } catch (UnsupportedEncodingException ex) {
            System.out.println(ex);
        } catch (IOException ex) {
            System.out.println(ex);
        }
        
        return salida;
    }
    
    public String report(String uri, LocalDate fechaInicio, LocalDate fechaFin) {
        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd/MM/yyyy");
        String fi = fechaInicio.format(formatter);
        String ff = fechaFin.format(formatter);
        
        String salida = null;
        
        try {
            CloseableHttpClient httpClient = Client.getHttpClient();
            
            URI uriParam = new URIBuilder(uri)
                    .addParameter("fechaInicio", fi)
                    .addParameter("fechaFin", ff)
                    .build();
            
            HttpGet httpGet = new HttpGet(uriParam);
            
            CloseableHttpResponse httpResponse = httpClient.execute(httpGet);
            
            int status = httpResponse.getStatusLine().getStatusCode();
            
            if (status >= 200 && status < 300) {
                salida = EntityUtils.toString(httpResponse.getEntity());
            }
            
            
        } catch (IOException ex) {
            System.out.println(ex);
        } catch (URISyntaxException ex) {
            System.out.println(ex);
        }
        
        return salida;
    }
    
    public boolean recover(String uri, String correo) {
        boolean salida = false;
        try {
            CloseableHttpClient httpClient = HttpClients.createDefault();
            
            String json = "{\"mailTo\" : \""+correo+"\"}";
            StringEntity entity = new StringEntity(json, "UTF-8");
            
            HttpUriRequest httpPost = RequestBuilder.post()
                    .setUri(uri)
                    .setHeader("Content-Type", "application/json")
                    .setEntity(entity)
                    .build();
            
            CloseableHttpResponse httpResponse = httpClient.execute(httpPost);
            
            int status = httpResponse.getStatusLine().getStatusCode();
            
            if (status >= 200 && status < 300) {
                salida = true;
            } else {
                salida = false;
            }
            
            
        } catch (IOException ex) {
            System.out.println(ex);
        }
        return salida;
    }
    
    public boolean recoverMarca(String uri, String correo) {
        boolean salida = false;
        try {
            CloseableHttpClient httpClient = HttpClients.createDefault();
            
            String json = "{\"Nombre\" : \""+correo+"\"}";
            StringEntity entity = new StringEntity(json, "UTF-8");
            
            HttpUriRequest httpPost = RequestBuilder.post()
                    .setUri(uri)
                    .setHeader("Content-Type", "application/json")
                    .setEntity(entity)
                    .build();
            
            CloseableHttpResponse httpResponse = httpClient.execute(httpPost);
            
            int status = httpResponse.getStatusLine().getStatusCode();
            
            if (status >= 200 && status < 300) {
                salida = true;
            } else {
                salida = false;
            }
            
            
        } catch (IOException ex) {
            System.out.println(ex);
        }
        return salida;
    }
}
