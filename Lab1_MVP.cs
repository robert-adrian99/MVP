/* conventie de scriere in C#
    - clase cu litera mare si CamelCase
    - metode si proprietati cu litera mare si CamelCase
    - atributele si variabile cu litera mica si camelCase
*/

public class Clasa
{
    private string txt;   // atribut al clasei

    public string Txt     // proprietate a clasei
    {
        get               // read
        {
            return txt;
        }
        set               // write
        {
            txt = value;  // value e cuvant cheie care se inlocuieste cu valoarea la apelul lui set
        }
    }

    public int Nr { get; set; }; //proprietate scrisa condensat
}

Clasa cls = new Clasa();
cls.Txt = "Hello world";    // se apeleaza set
MessageBox.Show(cls.Txt);   // se apeleaza get

// clasa partiala
public partial class Clasa2
{
}

sender as Button     // arunca NullReferenceException daca nu poate converti
(Button)sender       // arunca InvalidCastException daca nu poate converti

// Pot scrie atributele separat nu neaparat in acelasi tag
<Button>
    <Button.FontWeight> Bold </Button.FontWeight>
    <Button.Content>
        <WrapPanel>
            <TextBlock Foreground="Red"> R </TextBlock>
            <TextBlock Foreground="Green"> G </TextBlock>
            <TextBlock Foreground="Blue"> B </TextBlock>
        </WrapPanel>
    </Button.Content>
</Button>

// TEMA: Panel-uri