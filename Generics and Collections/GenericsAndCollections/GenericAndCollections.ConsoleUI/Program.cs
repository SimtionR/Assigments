// See https://aka.ms/new-console-template for more information



using GenericsAndCollections.Library;

var  stringCollection= new GenericCollection<string>
    (new string[] {"first", "second", "third", "forth", "fifth","sixth"});


var s1= stringCollection.GetItem(3);
Console.WriteLine(s1);

stringCollection.SetItem("Not forth anymore", 3);

var s2 = stringCollection.GetItem(3);
Console.WriteLine(s2);

var index0 = stringCollection.GetItem(0);
var index3 = stringCollection.GetItem(3);
Console.WriteLine($"Before swap index 0 :{index0} - index 3: {index3}");



stringCollection.SwapItemsByIndex(0, 3);

index0 = stringCollection.GetItem(0);
index3 = stringCollection.GetItem(3);


Console.WriteLine($"After swap index 0 :{index0} - index 3: {index3}");


var index1 = stringCollection.GetItem(1);
var index5 =stringCollection.GetItem(5);

Console.WriteLine($"Before swap index 1 :{index1} - index 5: {index5}");

stringCollection.SwapItems("second", "sixth");

index1 = stringCollection.GetItem(1);
index5= stringCollection.GetItem(5);

Console.WriteLine($"After swap index 1 :{index1} - index 5: {index5}");


