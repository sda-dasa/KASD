
using Itr;
using MyArrayList;

namespace Itr
{

    public interface MYIterator<T>
    {

        bool HasNext();

        T Next();

        bool Remove();


    }


















    public interface MYListIterator<T>: MYIterator<T>
    {
        bool HasPrevious();

        T Previous();

        int PreviousIndex();

        int NextIndex();

        void Set(T el);
        
        void Add(T el);


    }



}










namespace program
{

    public class Program
    {

        static void Main(string[] args)
        {
            MyArrayList<string> a = new MyArrayList<string>();

            a.Add("hksdl"); a.Add("8hil"); a.Add("gti3"); a.Add("7fu53j"); a.Add("a8bls");


            string f = a.ListIterator().Next();

            a.ListIterator().Add(f);
            Console.WriteLine(a.Size);



        }



    }



}









































namespace MYCollections
{


    public interface MyList<T> : MyCollection<T>
    {
        void Add(int index, T e);
        //void AddAll(int index, MyCollection<T> elems);
        T Get(int index);
        int IndexOf(object o);
        int LastIndexOf(object o);
        MYListIterator<T> ListIterator();
        MYListIterator<T> ListIterator(int index);
        T Remove(int index);
        void Set(int index, T e);
        MyList<T> SubList(int fromIndex, int toIndex);
    }












    public interface MyNavigableSet<E>
    {


    }

    public interface MyNavigableMap<K, V>
    {


    }










}






