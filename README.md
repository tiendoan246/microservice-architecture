Zookeeper
run: 		zkserver

Kafka
run: 		.\bin\windows\kafka-server-start.bat ./config/server.properties
create topic:	kafka-topics.bat –create –zookeeper localhost:2181 –replication-factor 1 –partitions 1 –topic <TOPIC NAME>
producer:	kafka-console-producer.bat –broker-list localhost:9092 –topic <TOPIC NAME>
consumer:	kafka-console-consumer.bat –zookeeper localhost:2181 –topic <TOPIC NAME>