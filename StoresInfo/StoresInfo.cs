namespace Bebrik1;

public class StoresData
{
    // ╔════════════════════════════════════════════════╗
    // ║            Поля класса StoresData              ║
    // ╚════════════════════════════════════════════════╝
    private string storeId;
    private string storeName;
    private string location;
    private string[] employees;
    private string[] products;
    
    public string StoreId
    {
        get =>  storeId;
    }
    public string StoreName
    {
        get =>  storeName;
    }
    public string Location
    {
        get =>  location;
    }
    public string[] Employees
    {
        get =>  employees;
    }
    public string[] Products
    {
        get =>  products;
    }
    // ╔════════════════════════════════════════════════╗
    // ║                 Конструкторы                   ║
    // ╚════════════════════════════════════════════════╝
    public StoresData(string storeId, string storeName, string location, string[] employees, string[] products)
    {
        this.storeId = storeId;
        this.storeName = storeName;
        this.location = location;
        this.employees = employees;
        this.products = products;
    }
    public StoresData()
    {
        storeId = "";
        storeName = "";
        location = "";
        employees = new string[] {};
        products = new string[] {}; 
    }
}