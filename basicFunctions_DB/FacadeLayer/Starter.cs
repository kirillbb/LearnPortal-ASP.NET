namespace basicFunctions_DB.FacadeLayer
{
    using basicFunctions_DB.LogicLayer.Authorization;
    using basicFunctions_DB.LogicLayer.Operations;

    internal class Starter
    {
        public void Run()
        {
            do
            {
                TryAuthorizate();
            }
            while (AuthorizationControler.AuthorizatedUser == null);

            do
            {
                ChooseGeneralMenuItem();
            } while (true);
            //
        }

        private void ChooseGeneralMenuItem()
        {
            

            try
            {
                OperationControler.Control();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void TryAuthorizate()
        {
            PrintMenu.Authorization();

            try
            {
                AuthorizationControler.Control();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
