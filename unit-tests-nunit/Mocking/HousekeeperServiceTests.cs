﻿using Moq;
using unit_tests_web_api.Mocking;

namespace unit_tests_nunit.Mocking;

[TestFixture]
public class HousekeeperServiceTests
{
    private HousekeeperService _service;
    private Mock<IStatementGenerator> _statementGenerator;
    private Mock<IEmailSender> _emailSender;
    private Mock<IXtraMessageBox> _messageBox;
    private DateTime _statementDate = new DateTime(2017, 1, 1);
    private Housekeeper _housekeeper;

    [SetUp]
    public void SetUp()
    {
        _housekeeper = new Housekeeper {Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c"};
        var unitOfWork = new Mock<IUnitOfWork>();
        unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
        {
            _housekeeper
        }.AsQueryable());

        _statementGenerator = new Mock<IStatementGenerator>();
        _emailSender = new Mock<IEmailSender>();
        _messageBox = new Mock<IXtraMessageBox>();

        _service = new HousekeeperService(unitOfWork.Object, _statementGenerator.Object, _emailSender.Object,
            _messageBox.Object);
    }
    [Test]
    public void SendStatementEmails_WhenCalled_GenerateStatements()
    {
        _service.SendStatementEmails(_statementDate);

        _statementGenerator.Verify(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate));
    }
}