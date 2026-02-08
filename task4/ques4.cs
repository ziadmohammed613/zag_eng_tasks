using System;

namespace Question4 {
    class User {
        private int id { set; get; }
        private string name { set; get; }
        private int age { set; get; }
        private UserSnapShot snapShot { set; get; }
        public User (int id , string name , int age , UserSnapShot snapShot) {
            this.id = id;
            this.name = name;
            this.age = age;
            this.snapShot = snapShot;
        }
        public void UpdateAge() => age++;
        public void DisplayStatus() {
            System.Console.WriteLine($"ID: {id}");
            System.Console.WriteLine($"Name: {name}");
            System.Console.WriteLine($"Age: {age}");
            // System.Console.WriteLine($"SnapShot: {snapShot.ToString()}");
        }
        public void ToggleUser() => snapShot.ToggleActivation();
    }
    struct UserSnapShot {
        private bool isActive;
        public UserSnapShot (bool isActive) {
            this.isActive = isActive;
        }
        public string ToString() {
            return  isActive ? "Active" : "NOT Active" ;
        }
        public void ToggleActivation() => isActive = !isActive;

    }
    
    internal class Program {
        static void ByCopy(User user, UserSnapShot snp) {
            user.UpdateAge();
            snp.ToggleActivation();
        }
        static void ByRef(ref User user,ref UserSnapShot snp) {
            user.UpdateAge();
            snp.ToggleActivation();
        }
        static void Main() {
            UserSnapShot snapShot = new UserSnapShot(false);
            User user = new User(101,"Tamer El Gayar",33,snapShot);

            user.DisplayStatus();
            Console.WriteLine(snapShot.ToString());

            Console.WriteLine("===================");
            ByCopy(user,snapShot);
            user.DisplayStatus();
            Console.WriteLine(snapShot.ToString());
            /*
                user attributes changed though it's passed by copy , it's because it's a reference type variable
                snapshot is a struct so a copy is passed to the arguments
            
            */

            Console.WriteLine("===================");
            ByRef(ref user, ref snapShot);
            user.DisplayStatus();
            Console.WriteLine(snapShot.ToString());
            /*
                pass by ref , so both have changed no matter it's in the stack or the heap
            */
        }
    }
}
