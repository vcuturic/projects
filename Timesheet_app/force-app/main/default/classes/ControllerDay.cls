public with sharing class ControllerDay {
    // private String sortOrder = 'Date__c';

    public Day__c day { get; set; }

    public ControllerDay() {

        Id id = ApexPages.currentPage().getParameters().get('id');
        day = (id == null ) ? new Day__c() : [SELECT Name, Date__c FROM Day__c WHERE Id=:id ];
     }
    public List<Day__c> getDays(){
        List<Day__c> days = [SELECT Name, Date__c FROM Day__c ORDER BY Date__c ASC ];
        return days;
    }
    public PageReference weeklyTimesheets(){
        PageReference weeklyTimesheets = Page.WeeklyTimesheets;
        weeklyTimesheets.setRedirect(true);
        return weeklyTimesheets;
    }
    //PageReference pageRef = new PageReference('/apex/HelloWorld');
    public PageReference save(){
        try {
            upsert(day);
        } catch(System.DMLException e) {
            ApexPages.addMessages(e);
            return null;
        }
        //  After successful Save, navigate to the default view page
        // PageReference weeklyTimesheets = Page.WeeklyTimesheets;
        // weeklyTimesheets.setRedirect(true);
        // return (weeklyTimesheets);
        return null;
    }
}
