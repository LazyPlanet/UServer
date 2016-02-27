
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG_X86
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -unsafe -warn:4 -optimize- -debug "-define:DEBUG"
ASSEMBLY = Bin/Debug/UServer.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = Bin/Debug

USERVER_EXE_MDB_SOURCE=Bin/Debug/UServer.exe.mdb
USERVER_EXE_MDB=$(BUILD_DIR)/UServer.exe.mdb
USERVER_EXE_CONFIG_SOURCE=App.config
LOG4NET_DLL_SOURCE=Lib/log4net.dll
MICROSOFT_SCRIPTING_DLL_SOURCE=Lib/Microsoft.Scripting.dll
NEWTONSOFT_JSON_DLL_SOURCE=Lib/Newtonsoft.Json.dll
SERVICESTACK_CLIENT_DLL_SOURCE=Lib/ServiceStack.Client.dll
SERVICESTACK_INTERFACES_DLL_SOURCE=Lib/ServiceStack.Interfaces.dll
SERVICESTACK_INTERFACES_DLL_MDB_SOURCE=Lib/ServiceStack.Interfaces.dll.mdb
SERVICESTACK_TEXT_DLL_SOURCE=Lib/ServiceStack.Text.dll
PROTOBUF_NET_DLL_SOURCE=Lib/protobuf-net.dll
SERVICESTACK_COMMON_DLL_SOURCE=Lib/ServiceStack.Common.dll
SERVICESTACK_DLL_SOURCE=Lib/ServiceStack.dll
SERVICESTACK_REDIS_DLL_SOURCE=Lib/ServiceStack.Redis.dll
SERVICESTACK_REDIS_TESTS_DLL_SOURCE=Lib/ServiceStack.Redis.Tests.dll
SUPERSOCKET_COMMON_DLL_SOURCE=Lib/SuperSocket.Common.dll
SUPERSOCKET_DLR_DLL_SOURCE=Lib/SuperSocket.Dlr.dll
SUPERSOCKET_SOCKETBASE_DLL_SOURCE=Lib/SuperSocket.SocketBase.dll
SUPERSOCKET_FACILITY_DLL_SOURCE=Lib/SuperSocket.Facility.dll
SUPERSOCKET_SERVERMANAGER_DLL_SOURCE=Lib/SuperSocket.ServerManager.dll
SUPERSOCKET_WEBSOCKET_DLL_SOURCE=Lib/SuperSocket.WebSocket.dll
SUPERSOCKET_SOCKETENGINE_DLL_SOURCE=Lib/SuperSocket.SocketEngine.dll

endif

if ENABLE_RELEASE_X86
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -unsafe -warn:4 -optimize+
ASSEMBLY = Bin/Release/UServer.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = Bin/Release

USERVER_EXE_MDB=
USERVER_EXE_CONFIG_SOURCE=App.config
LOG4NET_DLL_SOURCE=Lib/log4net.dll
MICROSOFT_SCRIPTING_DLL_SOURCE=Lib/Microsoft.Scripting.dll
NEWTONSOFT_JSON_DLL_SOURCE=Lib/Newtonsoft.Json.dll
SERVICESTACK_CLIENT_DLL_SOURCE=Lib/ServiceStack.Client.dll
SERVICESTACK_INTERFACES_DLL_SOURCE=Lib/ServiceStack.Interfaces.dll
SERVICESTACK_INTERFACES_DLL_MDB_SOURCE=Lib/ServiceStack.Interfaces.dll.mdb
SERVICESTACK_TEXT_DLL_SOURCE=Lib/ServiceStack.Text.dll
PROTOBUF_NET_DLL_SOURCE=Lib/protobuf-net.dll
SERVICESTACK_COMMON_DLL_SOURCE=Lib/ServiceStack.Common.dll
SERVICESTACK_DLL_SOURCE=Lib/ServiceStack.dll
SERVICESTACK_REDIS_DLL_SOURCE=Lib/ServiceStack.Redis.dll
SERVICESTACK_REDIS_TESTS_DLL_SOURCE=Lib/ServiceStack.Redis.Tests.dll
SUPERSOCKET_COMMON_DLL_SOURCE=Lib/SuperSocket.Common.dll
SUPERSOCKET_DLR_DLL_SOURCE=Lib/SuperSocket.Dlr.dll
SUPERSOCKET_SOCKETBASE_DLL_SOURCE=Lib/SuperSocket.SocketBase.dll
SUPERSOCKET_FACILITY_DLL_SOURCE=Lib/SuperSocket.Facility.dll
SUPERSOCKET_SERVERMANAGER_DLL_SOURCE=Lib/SuperSocket.ServerManager.dll
SUPERSOCKET_WEBSOCKET_DLL_SOURCE=Lib/SuperSocket.WebSocket.dll
SUPERSOCKET_SOCKETENGINE_DLL_SOURCE=Lib/SuperSocket.SocketEngine.dll

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(USERVER_EXE_MDB) \
	$(USERVER_EXE_CONFIG) \
	$(LOG4NET_DLL) \
	$(MICROSOFT_SCRIPTING_DLL) \
	$(NEWTONSOFT_JSON_DLL) \
	$(SERVICESTACK_CLIENT_DLL) \
	$(SERVICESTACK_INTERFACES_DLL) \
	$(SERVICESTACK_INTERFACES_DLL_MDB) \
	$(SERVICESTACK_TEXT_DLL) \
	$(PROTOBUF_NET_DLL) \
	$(SERVICESTACK_COMMON_DLL) \
	$(SERVICESTACK_DLL) \
	$(SERVICESTACK_REDIS_DLL) \
	$(SERVICESTACK_REDIS_TESTS_DLL) \
	$(SUPERSOCKET_COMMON_DLL) \
	$(SUPERSOCKET_DLR_DLL) \
	$(SUPERSOCKET_SOCKETBASE_DLL) \
	$(SUPERSOCKET_FACILITY_DLL) \
	$(SUPERSOCKET_SERVERMANAGER_DLL) \
	$(SUPERSOCKET_WEBSOCKET_DLL) \
	$(SUPERSOCKET_SOCKETENGINE_DLL)  

BINARIES = \
	$(USERVER)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES) 

FILES = \
	Main.cs \
	AssemblyInfo.cs \
	Chat/ChatManager.cs \
	Config/ConfignManager.cs \
	Database/DataBaseManager.cs \
	Event/BaseEvent.cs \
	Event/EventManager.cs \
	Log/LogWriter.cs \
	Network/SessiongManager.cs \
	Task/TaskInterface.cs \
	Template/TemplateManager.cs \
	Trrain/Grid.cs \
	Trrain/Scene.cs \
	Trrain/SceneManager.cs \
	Trrain/Slice.cs \
	Logic/Player.cs \
	Logic/Scene.cs \
	Logic/SceneManager.cs \
	Share/BaseThread.cs \
	Share/ByteBuffer.cs \
	Share/ProtoUtil.cs \
	Share/Protocal.cs \
	Share/UtilTools.cs \
	Logic/Vector3.cs \
	Pb/Share_Common.cs \
	Protobuf-net/BclHelpers.cs \
	Protobuf-net/BufferExtension.cs \
	Protobuf-net/BufferPool.cs \
	Protobuf-net/CallbackAttributes.cs \
	Protobuf-net/DataFormat.cs \
	Protobuf-net/Extensible.cs \
	Protobuf-net/ExtensibleUtil.cs \
	Protobuf-net/GlobalSuppressions.cs \
	Protobuf-net/Helpers.cs \
	Protobuf-net/IExtensible.cs \
	Protobuf-net/IExtension.cs \
	Protobuf-net/ImplicitFields.cs \
	Protobuf-net/KeyValuePairProxy.cs \
	Protobuf-net/NetObjectCache.cs \
	Protobuf-net/PrefixStyle.cs \
	Protobuf-net/ProtoContractAttribute.cs \
	Protobuf-net/ProtoConverterAttribute.cs \
	Protobuf-net/ProtoEnumAttribute.cs \
	Protobuf-net/ProtoException.cs \
	Protobuf-net/ProtoIgnoreAttribute.cs \
	Protobuf-net/ProtoIncludeAttribute.cs \
	Protobuf-net/ProtoMemberAttribute.cs \
	Protobuf-net/ProtoReader.cs \
	Protobuf-net/ProtoWriter.cs \
	Protobuf-net/SerializationContext.cs \
	Protobuf-net/Serializer.cs \
	Protobuf-net/SubItemToken.cs \
	Protobuf-net/WireType.cs \
	Protobuf-net/Compiler/CompilerContext.cs \
	Protobuf-net/Compiler/CompilerDelegates.cs \
	Protobuf-net/Compiler/Local.cs \
	Protobuf-net/Meta/AttributeMap.cs \
	Protobuf-net/Meta/BasicList.cs \
	Protobuf-net/Meta/CallbackSet.cs \
	Protobuf-net/Meta/MetaType.cs \
	Protobuf-net/Meta/RuntimeTypeModel.cs \
	Protobuf-net/Meta/SubType.cs \
	Protobuf-net/Meta/TypeFormatEventArgs.cs \
	Protobuf-net/Meta/TypeModel.cs \
	Protobuf-net/Meta/ValueMember.cs \
	Protobuf-net/Properties/AssemblyInfo.cs \
	Protobuf-net/Serializers/ArrayDecorator.cs \
	Protobuf-net/Serializers/BlobSerializer.cs \
	Protobuf-net/Serializers/BooleanSerializer.cs \
	Protobuf-net/Serializers/ByteSerializer.cs \
	Protobuf-net/Serializers/CharSerializer.cs \
	Protobuf-net/Serializers/CompiledSerializer.cs \
	Protobuf-net/Serializers/DateTimeSerializer.cs \
	Protobuf-net/Serializers/DecimalSerializer.cs \
	Protobuf-net/Serializers/DefaultValueDecorator.cs \
	Protobuf-net/Serializers/DoubleSerializer.cs \
	Protobuf-net/Serializers/EnumSerializer.cs \
	Protobuf-net/Serializers/FieldDecorator.cs \
	Protobuf-net/Serializers/GuidSerializer.cs \
	Protobuf-net/Serializers/ImmutableCollectionDecorator.cs \
	Protobuf-net/Serializers/Int16Serializer.cs \
	Protobuf-net/Serializers/Int32Serializer.cs \
	Protobuf-net/Serializers/Int64Serializer.cs \
	Protobuf-net/Serializers/IProtoSerializer.cs \
	Protobuf-net/Serializers/IProtoTypeSerializer.cs \
	Protobuf-net/Serializers/ISerializerProxy.cs \
	Protobuf-net/Serializers/KeyValuePairDecorator.cs \
	Protobuf-net/Serializers/ListDecorator.cs \
	Protobuf-net/Serializers/MemberSpecifiedDecorator.cs \
	Protobuf-net/Serializers/NetObjectSerializer.cs \
	Protobuf-net/Serializers/NullDecorator.cs \
	Protobuf-net/Serializers/ParseableSerializer.cs \
	Protobuf-net/Serializers/PropertyDecorator.cs \
	Protobuf-net/Serializers/ProtoDecoratorBase.cs \
	Protobuf-net/Serializers/SByteSerializer.cs \
	Protobuf-net/Serializers/SingleSerializer.cs \
	Protobuf-net/Serializers/StringSerializer.cs \
	Protobuf-net/Serializers/SubItemSerializer.cs \
	Protobuf-net/Serializers/SurrogateSerializer.cs \
	Protobuf-net/Serializers/SystemTypeSerializer.cs \
	Protobuf-net/Serializers/TagDecorator.cs \
	Protobuf-net/Serializers/TimeSpanSerializer.cs \
	Protobuf-net/Serializers/TupleSerializer.cs \
	Protobuf-net/Serializers/TypeSerializer.cs \
	Protobuf-net/Serializers/UInt16Serializer.cs \
	Protobuf-net/Serializers/UInt32Serializer.cs \
	Protobuf-net/Serializers/UInt64Serializer.cs \
	Protobuf-net/Serializers/UriDecorator.cs \
	Protobuf-net/ServiceModel/ProtoBehaviorAttribute.cs \
	Protobuf-net/ServiceModel/ProtoBehaviorExtensionElement.cs \
	Protobuf-net/ServiceModel/ProtoEndpointBehavior.cs \
	Protobuf-net/ServiceModel/ProtoOperationBehavior.cs \
	Protobuf-net/ServiceModel/XmlProtoSerializer.cs \
	Logic/Creature.cs \
	Logic/MQManager.cs \
	Logic/LogicServer.cs \
	Network/Session.cs \
	Network/ClientReceiveFilter.cs \
	Database/RedisConfigInfo.cs \
	Database/RedisManager.cs \
	Database/RedisOperatorBase.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	Chat \
	Config \
	Data \
	Database \
	Event \
	Log \
	Network \
	Pb \
	Task \
	Template \
	Trrain \
	Lib \
	Logic \
	Share \
	Protobuf-net \
	Data/map \
	App.config \
	Data/Medichine/大经验丹 \
	Data/Mine/矿 \
	Lib/ServiceStack.Client.dll \
	Lib/ServiceStack.Client.xml \
	Lib/ServiceStack.Common.dll \
	Lib/ServiceStack.Common.xml \
	Lib/ServiceStack.Interfaces.dll \
	Lib/ServiceStack.Interfaces.dll.mdb \
	Lib/ServiceStack.Redis.Tests.dll \
	Lib/ServiceStack.Redis.dll \
	Lib/ServiceStack.Text.4.0.0.nupkg \
	Lib/ServiceStack.Text.4.0.0.symbols.nupkg \
	Lib/ServiceStack.Text.XML \
	Lib/ServiceStack.Text.dll \
	Lib/ServiceStack.dll \
	Lib/ServiceStack.xml \
	Lib/nunit.framework.xml \
	Lib/protobuf-net.pdb \
	Protobuf-net/project.json \
	Protobuf-net/project.lock.json \
	Protobuf-net/protobuf-net.csproj \
	Protobuf-net/protobuf_net.xproj \
	Protobuf-net/Web/TODO.txt \
	Pb/Share_Common.proto \
	Logic/NpcList.xml \
	Data/map/npcs.xml \
	userver.in 

REFERENCES =  \
	System.Net \
	System.Configuration \
	System.ComponentModel.Composition \
	System.ComponentModel.DataAnnotations \
	System.Drawing \
	System.Core \
	System

DLL_REFERENCES =  \
	../../../../../../log4net \
	../../../../../../Microsoft.Scripting \
	../../../../../../Newtonsoft.Json \
	../../../../../../ServiceStack.Client \
	../../../../../../protobuf-net \
	../../../../../../ServiceStack.Common \
	../../../../../../ServiceStack \
	../../../../../../ServiceStack.Interfaces \
	../../../../../../ServiceStack.Redis \
	../../../../../../ServiceStack.Redis.Tests \
	../../../../../../ServiceStack.Text \
	../../../../../../SuperSocket.Common \
	../../../../../../SuperSocket.Dlr \
	../../../../../../SuperSocket.Facility \
	../../../../../../SuperSocket.ServerManager \
	../../../../../../SuperSocket.SocketBase \
	../../../../../../SuperSocket.SocketEngine \
	../../../../../../SuperSocket.WebSocket

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

include $(top_srcdir)/Makefile.include

USERVER_EXE_CONFIG = $(BUILD_DIR)/UServer.exe.config
LOG4NET_DLL = $(BUILD_DIR)/log4net.dll
MICROSOFT_SCRIPTING_DLL = $(BUILD_DIR)/Microsoft.Scripting.dll
NEWTONSOFT_JSON_DLL = $(BUILD_DIR)/Newtonsoft.Json.dll
SERVICESTACK_CLIENT_DLL = $(BUILD_DIR)/ServiceStack.Client.dll
SERVICESTACK_INTERFACES_DLL = $(BUILD_DIR)/ServiceStack.Interfaces.dll
SERVICESTACK_INTERFACES_DLL_MDB = $(BUILD_DIR)/ServiceStack.Interfaces.dll.mdb
SERVICESTACK_TEXT_DLL = $(BUILD_DIR)/ServiceStack.Text.dll
PROTOBUF_NET_DLL = $(BUILD_DIR)/protobuf-net.dll
SERVICESTACK_COMMON_DLL = $(BUILD_DIR)/ServiceStack.Common.dll
SERVICESTACK_DLL = $(BUILD_DIR)/ServiceStack.dll
SERVICESTACK_REDIS_DLL = $(BUILD_DIR)/ServiceStack.Redis.dll
SERVICESTACK_REDIS_TESTS_DLL = $(BUILD_DIR)/ServiceStack.Redis.Tests.dll
SUPERSOCKET_COMMON_DLL = $(BUILD_DIR)/SuperSocket.Common.dll
SUPERSOCKET_DLR_DLL = $(BUILD_DIR)/SuperSocket.Dlr.dll
SUPERSOCKET_SOCKETBASE_DLL = $(BUILD_DIR)/SuperSocket.SocketBase.dll
SUPERSOCKET_FACILITY_DLL = $(BUILD_DIR)/SuperSocket.Facility.dll
SUPERSOCKET_SERVERMANAGER_DLL = $(BUILD_DIR)/SuperSocket.ServerManager.dll
SUPERSOCKET_WEBSOCKET_DLL = $(BUILD_DIR)/SuperSocket.WebSocket.dll
SUPERSOCKET_SOCKETENGINE_DLL = $(BUILD_DIR)/SuperSocket.SocketEngine.dll
USERVER = $(BUILD_DIR)/userver

$(eval $(call emit-deploy-target,USERVER_EXE_CONFIG))
$(eval $(call emit-deploy-target,LOG4NET_DLL))
$(eval $(call emit-deploy-target,MICROSOFT_SCRIPTING_DLL))
$(eval $(call emit-deploy-target,NEWTONSOFT_JSON_DLL))
$(eval $(call emit-deploy-target,SERVICESTACK_CLIENT_DLL))
$(eval $(call emit-deploy-target,SERVICESTACK_INTERFACES_DLL))
$(eval $(call emit-deploy-target,SERVICESTACK_INTERFACES_DLL_MDB))
$(eval $(call emit-deploy-target,SERVICESTACK_TEXT_DLL))
$(eval $(call emit-deploy-target,PROTOBUF_NET_DLL))
$(eval $(call emit-deploy-target,SERVICESTACK_COMMON_DLL))
$(eval $(call emit-deploy-target,SERVICESTACK_DLL))
$(eval $(call emit-deploy-target,SERVICESTACK_REDIS_DLL))
$(eval $(call emit-deploy-target,SERVICESTACK_REDIS_TESTS_DLL))
$(eval $(call emit-deploy-target,SUPERSOCKET_COMMON_DLL))
$(eval $(call emit-deploy-target,SUPERSOCKET_DLR_DLL))
$(eval $(call emit-deploy-target,SUPERSOCKET_SOCKETBASE_DLL))
$(eval $(call emit-deploy-target,SUPERSOCKET_FACILITY_DLL))
$(eval $(call emit-deploy-target,SUPERSOCKET_SERVERMANAGER_DLL))
$(eval $(call emit-deploy-target,SUPERSOCKET_WEBSOCKET_DLL))
$(eval $(call emit-deploy-target,SUPERSOCKET_SOCKETENGINE_DLL))
$(eval $(call emit-deploy-wrapper,USERVER,userver,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
