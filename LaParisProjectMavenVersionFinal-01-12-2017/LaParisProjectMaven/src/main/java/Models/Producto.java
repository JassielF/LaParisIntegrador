/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Models;

/**
 *
 * @author XD
 */
public class Producto {
    private int Id;
    private String Nombre;
    private int Cantidad;
    private String Sku;
    private String Detalle;
    private String Imagen;
    private Double Promocion;
    private int idCategoria;
    public Categoria Categoria;
    private int idSucursal;
    public Sucursal Sucursal;
    private int idMarca;
    public Marca Marca;

    public int getId() {
        return Id;
    }

    public void setId(int Id) {
        this.Id = Id;
    }

    public String getNombre() {
        return Nombre;
    }

    public void setNombre(String Nombre) {
        this.Nombre = Nombre;
    }

    public int getCantidad() {
        return Cantidad;
    }

    public void setCantidad(int Cantidad) {
        this.Cantidad = Cantidad;
    }

    public String getSku() {
        return Sku;
    }

    public void setSku(String Sku) {
        this.Sku = Sku;
    }

    public String getDetalle() {
        return Detalle;
    }

    public void setDetalle(String Detalle) {
        this.Detalle = Detalle;
    }

    public String getImagen() {
        return Imagen;
    }

    public void setImagen(String Imagen) {
        this.Imagen = Imagen;
    }

    public Double getPromocion() {
        return Promocion;
    }

    public void setPromocion(Double Promocion) {
        this.Promocion = Promocion;
    }

    public int getIdCategoria() {
        return idCategoria;
    }

    public void setIdCategoria(int idCategoria) {
        this.idCategoria = idCategoria;
    }

    public Categoria getCategoria() {
        return Categoria;
    }

    public void setCategoria(Categoria Categoria) {
        this.Categoria = Categoria;
    }

    public int getIdSucursal() {
        return idSucursal;
    }

    public void setIdSucursal(int idSucursal) {
        this.idSucursal = idSucursal;
    }

    public Sucursal getSucursal() {
        return Sucursal;
    }

    public void setSucursal(Sucursal Sucursal) {
        this.Sucursal = Sucursal;
    }

    public int getIdMarca() {
        return idMarca;
    }

    public void setIdMarca(int idMarca) {
        this.idMarca = idMarca;
    }

    public Marca getMarca() {
        return Marca;
    }

    public void setMarca(Marca Marca) {
        this.Marca = Marca;
    }
}
