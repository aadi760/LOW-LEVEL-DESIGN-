// The Single Responsibility Principle states that a class should have only one reason to change.
// In other words, a class should have only one responsibility or job.
// This principle helps to keep the codebase clean, maintainable, and easier to understand.

using System;

namespace SolidPrinciples
{
    class Marker
    {
        int price;
        string color;

        Marker(int price, string color)
        {
            this.price = price;
            this.color = color;
        }

        public void Draw()
        {
            Console.WriteLine("Drawing a marker");
        }

    }

    class Invoice
    {
        Marker marker;
        int Quantity;
        Invoice(Marker marker, int quantity)
        {
            this.marker = marker;
            this.Quantity = quantity;
        }
        public int CalculateTotal()
        {
            int price = Quantity * marker.price;   // This is one Reponsibility
            return price;
        }

        public void PrintInvoice()
        {
            Console.WriteLine("Printing Invoice"); // This is another Responsibility
        }

        public void saveInvoiceToDb()
        {
            Console.WriteLine("Saving Invoice to Database");// This is another Responsibility
        }
    }

    // this is voilation of Single Responsibility Principle because the Invoice class has multiple responsibilities.
    // to resolve that 

    class Invoice
    {
        Marker marker;
        int Quantity;
        Invoice(Marker marker, int quantity)
        {
            this.marker = marker;
            this.Quantity = quantity;
        }
        public int CalculateTotal()
        {
            int price = Quantity * marker.price;   // This is one Reponsibility
            return price;
        }

    }

    class InvoicePrinter
    {
        Invoice invoice;
        InvoicePrinter(Invoice invoice)
        {
            this.invoice = invoice;
        }
        public void PrintInvoice(Invoice invoice)
        {
            Console.WriteLine("Printing Invoice"); // this is one Responsibility
        }
    }

    class Inoicedac {      
        Invoice invoice;
        Inoicedac(Invoice invoice)
        {
            this.invoice = invoice;
        }
        public void saveInvoiceToDb(Invoice invoice)
        {
            Console.WriteLine("Saving Invoice to Database");// this is one Responsibility
        }
    }

    // now this follows the Single Responsibility Principle because each class has only one responsibility.

    class Program
    {
        static void Main(string[] args)
        {
          Marker marker = new Marker(10, "Black");
          Invoice invoice = new Invoice(marker, 5);
          int total = invoice.CalculateTotal();
          Console.WriteLine("Total Price: " + total);
          InvoicePrinter printer = new InvoicePrinter(invoice);
          printer.PrintInvoice(invoice);
          Inoicedac dac = new Inoicedac(invoice);
          dac.saveInvoiceToDb(invoice);
        }
    }
}
 