using CommonServiceLocator;
using QuizUp.ViewModels;
using Unity;
using Unity.Lifetime;
using Unity.ServiceLocation;

namespace QuizUp.Unity
{
    public class ViewModelLocator
    {
        private readonly UnityContainer _unityContainer;

        public LoginViewModel LoginViewModel
        {
            get
            {
                return _unityContainer.Resolve<LoginViewModel>();
            }
        }

        public LogoutDetailViewModel LogoutDetailViewModel
        {
            get
            {
                return _unityContainer.Resolve<LogoutDetailViewModel>();
            }
        }

        public ForgotPasswordViewModel ForgotPasswordViewModel
        {
            get
            {
                return _unityContainer.Resolve<ForgotPasswordViewModel>();
            }
        }

        public SignUpViewModel SignUpViewModel
        {
            get
            {
                return _unityContainer.Resolve<SignUpViewModel>();
            }
        }

        public MasterHomeMasterViewModel MasterHomeMasterViewModel
        {
            get
            {
                return _unityContainer.Resolve<MasterHomeMasterViewModel>();
            }
        }

        public AboutUsDetailViewModel AboutUsDetailViewModel
        {
            get
            {
                return _unityContainer.Resolve<AboutUsDetailViewModel>();
            }
        }

        public MasterHomeDetailViewModel MasterHomeDetailViewModel
        {
            get
            {
                return _unityContainer.Resolve<MasterHomeDetailViewModel>();
            }
        }

        public MyProfileDetailViewModel MyProfileDetailViewModel
        {
            get
            {
                return _unityContainer.Resolve<MyProfileDetailViewModel>();
            }
        }

        public ScoreCardDetailViewModel ScoreCardDetailViewModel
        {
            get
            {
                return _unityContainer.Resolve<ScoreCardDetailViewModel>();
            }
        }

        public TakeQuizDetailViewModel TakeQuizDetailViewModel
        {
            get
            {
                return _unityContainer.Resolve<TakeQuizDetailViewModel>();
            }
        }

        public AllAttemptTabbedDetailViewModel AllAttemptTabbedDetailViewModel
        {
            get
            {
                return _unityContainer.Resolve<AllAttemptTabbedDetailViewModel>();
            }
        }

        public LastAttemptTabbedDetailViewModel LastAttemptTabbedDetailViewModel
        {
            get
            {
                return _unityContainer.Resolve<LastAttemptTabbedDetailViewModel>();
            }
        }

        public ViewModelLocator()
        {
            _unityContainer = new UnityContainer();

            _unityContainer.RegisterType<LoginViewModel>(new TransientLifetimeManager());
            _unityContainer.RegisterType<ForgotPasswordViewModel>(new TransientLifetimeManager());
            _unityContainer.RegisterType<SignUpViewModel>(new HierarchicalLifetimeManager());
            _unityContainer.RegisterType<MasterHomeMasterViewModel>(new TransientLifetimeManager());
            _unityContainer.RegisterType<AboutUsDetailViewModel>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<MasterHomeDetailViewModel>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<ScoreCardDetailViewModel>(new TransientLifetimeManager());
            _unityContainer.RegisterType<TakeQuizDetailViewModel>(new TransientLifetimeManager());
            _unityContainer.RegisterType<MyProfileDetailViewModel>(new HierarchicalLifetimeManager());
            _unityContainer.RegisterType<LogoutDetailViewModel>(new HierarchicalLifetimeManager());
            _unityContainer.RegisterType<AllAttemptTabbedDetailViewModel>(new TransientLifetimeManager());
            _unityContainer.RegisterType<LastAttemptTabbedDetailViewModel>(new TransientLifetimeManager());

            var unityServiceLocator = new UnityServiceLocator(_unityContainer);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);
        }
    }
}
