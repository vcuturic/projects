public without sharing class TimesheetsProcessor implements Database.Batchable<SObject>{

    List<String> toAddresses = new List<String>();

    public Database.QueryLocator start(Database.BatchableContext dbc){
        return Database.getQueryLocator([SELECT Id FROM Person__c]);
    }
    public void execute(Database.BatchableContext dbc, List<Person__c> persons){
        for (Person__c p : persons) {
            toAddresses.add(p.E_Mail__c);
        }
    }
    public void sendmail()
    {
        Messaging.SingleEmailMessage email = new Messaging.SingleEmailMessage();
        // string [] toaddress= New string[]{'vikky15.99@gmail.com'};
        email.setSubject('Ispunite vaše nedeljne zadatke');
        email.setPlainTextBody('Testing Apex Scheduler-Body');
        email.setToAddresses(toaddress);
        Messaging.sendEmail(New Messaging.SingleEmailMessage[]{email});
    }
}
