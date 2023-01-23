//using Casino.Exceptions;
//using Casino.Services;
//using Casino.Wrappers;
//using Moq;
//using Xunit;

//namespace Casino.Tests
//{
//    public class TransactionServiceTests
//    {
//        private readonly TransactionService _transactionService;
//        private readonly Mock<IConsole> _console;

//        public TransactionServiceTests()
//        {
//            this._console = new Mock<IConsole>();
//            this._transactionService = new TransactionService(this._console.Object);
//        }

//        [Fact]
//        public void Deposit_ValidAmount_UpdatesBalance()
//        {
//            // Arrange
//            this._console.Setup(c => c.ReadLine())
//                .Returns("10");

//            // Act
//            this._transactionService.Deposit();

//            // Assert
//            Assert.Equal(10, this._transactionService.Balance);
//            this._console.Verify(c => c.WriteLine(GlobalConstants.DEPOSIT_MONEY_SUCCESSFUL + " 10"), Times.Once);
//        }

//        [Fact]
//        public void Deposit_InvalidAmount_ThrowsInvalidAmountException()
//        {
//            // Arrange
//            this._console.Setup(c => c.ReadLine())
//                .Returns("invalid");

//            // Act
//            var ex = Assert.Throws<InvalidAmountException>(() => this._transactionService.Deposit());

//            // Assert
//            Assert.Equal(0, this._transactionService.Balance);
//            this._console.Verify(c => c.WriteLine(GlobalConstants.DEPOSIT_MONEY_SUCCESSFUL), Times.Never);
//        }

//        [Fact]
//        public void Withdraw_ValidAmount_UpdatesBalance()
//        {
//            // Arrange
//            this._console.Setup(c => c.ReadLine())
//                .Returns("10");

//            this._transactionService.Deposit();

//            this._console.Setup(c => c.ReadLine())
//                .Returns("5");

//            // Act
//            this._transactionService.Withdraw();

//            // Assert
//            Assert.Equal(5, this._transactionService.Balance);
//            this._console.Verify(c => c.WriteLine(GlobalConstants.WITHDRAWAL_SUCCESSFUL + " 5"), Times.Once);
//        }

//        [Fact]
//        public void Withdraw_InvalidAmount_ThrowsInvalidAmountException()
//        {
//            // Arrange
//            this._console.Setup(c => c.ReadLine())
//                .Returns("not a number");

//            // Act and Assert
//            var ex = Assert.Throws<InvalidAmountException>(() => this._transactionService.Withdraw());
//            Assert.Equal(GlobalConstants.INVALID_WITHDRAWAL_AMOUNT, ex.Message);
//        }

//        [Fact]
//        public void Deposit_ValidAmount_AddsToBalance()
//        {
//            // Arrange
//            this._console.SetupSequence(c => c.ReadLine())
//                .Returns("10")
//                .Returns("5");

//            // Act
//            this._transactionService.Deposit();
//            this._transactionService.Deposit();

//            // Assert
//            Assert.Equal(15, this._transactionService.Balance);
//        }

//        [Fact]
//        public void Deposit_ZeroAmount_ThrowsInvalidAmountException()
//        {
//            // Arrange
//            this._console.Setup(c => c.ReadLine()).Returns("0");

//            // Act & Assert
//            Assert.Throws<InvalidAmountException>(() => this._transactionService.Deposit());
//        }
//    }
//}