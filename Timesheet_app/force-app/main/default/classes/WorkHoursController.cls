public with sharing class WorkHoursController {

//     public WorkHours__c wh {get; set;}

    public WorkHoursController() {
        
        
    }

//     public List<WorkHours__c> getWHours(){
//         List<WorkHours__c> wHours = [SELECT Hours__c, MyTask__c, projectId__c FROM WorkHours__c ORDER BY Date__c ASC ];
//         return wHours;
//     }
//     // public PageReference weeklyTimesheets(){
//     //     PageReference weeklyTimesheets = Page.WeeklyTimesheets;
//     //     weeklyTimesheets.setRedirect(true);
//     //     return weeklyTimesheets;
//     // }
//     //PageReference pageRef = new PageReference('/apex/HelloWorld');
//     public PageReference save(){
//         try {
//             upsert(wh);
//         } catch(System.DMLException e) {
//             ApexPages.addMessages(e);
//             return null;
//         }
//         //  After successful Save, navigate to the default view page
//         // PageReference weeklyTimesheets = Page.WeeklyTimesheets;
//         // weeklyTimesheets.setRedirect(true);
//         // return (weeklyTimesheets);
//         return null;
//     }
}
