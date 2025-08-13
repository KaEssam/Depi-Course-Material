
//namespace QAL_S1_Day4
//{
//    class Magazine : LibraryItem
//    {
//        public int ISBN { get; set; }
//        public string Title { get; set; }
//        public string Author { get; set; }

//        public override string ItemType => throw new NotImplementedException();

//        //public override void DisplyInfo()
//        //{
//        //    throw new NotImplementedException();
//        //}

//        public override void hello()
//        {
//            throw new NotImplementedException();
//        }

//        private bool _isAvilable = true;

//        public bool Borrow(string borrowName)
//        {
//            if (!_isAvilable)
//            {
//                return false;
//            }
//            else
//            {
//                Console.WriteLine("ok");
//                _isAvilable = false;
//                return true;
//            }
//        }

//        protected override bool Borrow(string itemName)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
