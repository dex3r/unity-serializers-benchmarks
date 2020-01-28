# Unity Serializers Benchmarks

Which deserializer (I only care about the deserialization part) is fastest when it comes to deserialization, access and creates least garbage on **Unity IL2CPP Android** platform? This is the question that this set of benchmarks is trying to answer.

The tests data sets:
 - Type with 20 fields with one nested dictionary, indexed by int with type containing 10 scalar fields and one 15-elements array.
 - Type with 2 scalar fields
 
 Tests:
 - deserialization time
 - access time to random fields
 - GC overhead

Bonus: can they be used exchangedly? 
