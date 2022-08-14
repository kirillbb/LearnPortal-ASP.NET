namespace basicFunctions_DB.FacadeLayer
{
    using basicFunctions_DB.LogicLayer.Authorization;

    internal class Starter
    {
        public void Run()
        {
            do
            {
                TryAuthorizate();
            }
            while (AuthorizationControler.AuthorizatedUser == null);

            //
        }

        private void TryAuthorizate()
        {
            Menu.Authorization();

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
