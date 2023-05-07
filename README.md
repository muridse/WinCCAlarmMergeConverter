# WinCCAlarmMergeConverter
 WinCCAlarmMergeConverter is a utility for bulk renaming of classes and types in an alarm export file from a winss project. This utility is needed when merging two projects and further integrating alarms from one project into another.

# How to use?
1. Export alarms from the first winss project
2. Place the resulting .txt file in the "AlarmFiles" folder and rename it to template.txt
3. Set the necessary replacements for classes and types in the "Config" folder
(example, class config: original class name -> new name)
4. Run the program
5. Import the resulting TemplateModed.txt file into the second project
