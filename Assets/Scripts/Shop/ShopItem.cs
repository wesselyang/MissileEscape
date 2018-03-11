/// <summary>
/// Shop items object class.
/// Author: Mingxi Yang 104563133
/// </summary>

public class ShopItem {

    private string speed;
    private string rotate;
    private string model;
    private string price;

    public ShopItem(string speed, string rotate, string model, string price)
    {
        this.speed = speed;
        this.rotate = rotate;
        this.model = model;
        this.price = price;
    }

    public string Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    
    public string Rotate
    {
        get { return rotate; }
        set { rotate = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public string Price
    {
        get { return price; }
        set { price = value; }
    }

    public override string ToString()
    {
        return string.Format("speed:{0}, rotate:{1}, model:{2}, price:{3}.", speed, rotate, model, price);
    }

}
