echo "Start ZooKeeper server"
start cmd.exe /k "D:/Services/zookeeper-3.4.14/bin/zkserver"

echo "Start Kafka server"
start cmd.exe /k "D:/Services/kafka_2.12-2.2.0/bin/windows/kafka-server-start.bat D:/Services/kafka_2.12-2.2.0/config/server.properties"