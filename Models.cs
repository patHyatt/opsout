using System.Collections.Generic;

namespace opsout
{
    public class Key
    {
        public string key { get; set; }
    }

    public class PlanKey
    {
        public string key { get; set; }
    }

    public class Operations
    {
        public bool canView { get; set; }
        public bool canEdit { get; set; }
        public bool canDelete { get; set; }
        public bool allowedToExecute { get; set; }
        public bool canExecute { get; set; }
        public bool allowedToCreateVersion { get; set; }
        public bool allowedToSetVersionStatus { get; set; }
    }

    public class DeploymentProject
    {
        public int id { get; set; }
        public string oid { get; set; }
        public Key key { get; set; }
        public string name { get; set; }
        public PlanKey planKey { get; set; }
        public string description { get; set; }
        public List<Environment> environments { get; set; }
        public Operations operations { get; set; }
    }

    public class Environment
    {
        public int id { get; set; }
        public string name { get; set; }
        public int deploymentProjectId { get; set; }
        public Operations operations { get; set; }
        public int position { get; set; }
    }

    public class EntityKey
    {
        public string key { get; set; }
    }

    public class PlanResultKey
    {
        public string key { get; set; }
        public EntityKey entityKey { get; set; }
        public int resultNumber { get; set; }
    }

    public class Artifact
    {
        public int id { get; set; }
        public string label { get; set; }
        public int size { get; set; }
        public bool isSharedArtifact { get; set; }
        public bool isGloballyStored { get; set; }
        public string linkType { get; set; }
        public PlanResultKey planResultKey { get; set; }
        public string archiverType { get; set; }
    }

    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public PlanResultKey planResultKey { get; set; }
        public string type { get; set; }
        public string label { get; set; }
        public string location { get; set; }
        public string copyPattern { get; set; }
        public int size { get; set; }
        public Artifact artifact { get; set; }
    }


    public class DeploymentVersion
    {
        public int id { get; set; }
        public string name { get; set; }
        //public DateTime creationDate { get; set; }
        public string creatorUserName { get; set; }
        public List<Item> items { get; set; }
        public Operations operations { get; set; }
        public string creatorDisplayName { get; set; }
        public string creatorGravatarUrl { get; set; }
        public string planBranchName { get; set; }
        //public DateTime ageZeroPoint { get; set; }
    }

    public class Agent
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public bool active { get; set; }
        public bool enabled { get; set; }
        public bool busy { get; set; }
    }

    public class DeploymentResult
    {
        public DeploymentVersion deploymentVersion { get; set; }
        public string deploymentVersionName { get; set; }
        public int id { get; set; }
        public string deploymentState { get; set; }
        public string lifeCycleState { get; set; }
        //public DateTime startedDate { get; set; }
        //public DateTime queuedDate { get; set; }
        //public DateTime executedDate { get; set; }
        //public DateTime finishedDate { get; set; }
        public string reasonSummary { get; set; }
        public Key key { get; set; }
        public Agent agent { get; set; }
        public Operations operations { get; set; }
    }

    public class EnvironmentStatus
    {
        public Environment environment { get; set; }
        public DeploymentResult deploymentResult { get; set; }
    }

    public class ProjectDeployment
    {
        public DeploymentProject deploymentProject { get; set; }
        public List<EnvironmentStatus> environmentStatuses { get; set; }
    }
}
