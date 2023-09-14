using UnityEngine;

public class CannonTower : MonoBehaviour
{
    [SerializeField] float horizontalRotationSpeed;
    [SerializeField] float verticalRotationSpeed;
    [SerializeField] float maxVerticalRotationAngle = 30;
    [SerializeField] float maxAimDeflectionAngle = 1;
    [SerializeField] Transform horizontalRotator;
    [SerializeField] Transform verticalRotator;

    Vector3 predictiveTargetPosition;
    Vector3 ATargetPosition;
    Vector3 BTargetPosition;
    GameObject target;
    ProjectilesSpawner projectilesSpawner;
    UnitDetector unitsDectector;

    void OnEnable()
    {
        unitsDectector = GetComponent<UnitDetector>();
        projectilesSpawner = GetComponent<ProjectilesSpawner>();
        unitsDectector.attackTargetUpdatedEvent += SetTarget;
    }

    void OnDisable()
    {
        unitsDectector.attackTargetUpdatedEvent -= SetTarget;
    }

    void SetTarget(GameObject target)
    {
        this.target = target;
    }

    void FixedUpdate()
    {
        if (target)
        {
            ATargetPosition = BTargetPosition;
            BTargetPosition = target.transform.position;

            var targetVelocity = (BTargetPosition - ATargetPosition) / Time.fixedDeltaTime;

            if (ATargetPosition != Vector3.zero && BTargetPosition != Vector3.zero)
            {
                bool leadPositionCalculated = GetPredictivePosition(target.transform.position, verticalRotator.position, targetVelocity, projectilesSpawner.ProjectilePrefab.Speed, out predictiveTargetPosition);
                if (leadPositionCalculated)
                {
                    HorizontalRotation();
                    VerticalRotation();
                }
            }
        }

        var aimDeflectionAngle = Vector3.Angle(predictiveTargetPosition - verticalRotator.position, verticalRotator.forward);

        if (aimDeflectionAngle < maxAimDeflectionAngle)
            projectilesSpawner.SetAttackTarget(target);
        else
            projectilesSpawner.SetAttackTarget(null);
    }

    public bool GetPredictivePosition(Vector3 a, Vector3 b, Vector3 vA, float sB, out  Vector3 predictivePosition)
    {
        var aToB = b - a;
        var dC = aToB.magnitude;
        var alpha = Vector3.Angle(aToB, vA) * Mathf.Deg2Rad;
        var sA = vA.magnitude;
        var r = sA / sB;
        var rootsNumber = ModelUtils.SolveQuadratic(1 - r * r, 2 * r * dC * Mathf.Cos(alpha), -(dC * dC), out var root1, out var root2);
        if (rootsNumber == 0)
        {
            predictivePosition = Vector3.zero;
            return false;
        }
        var dA = Mathf.Max(root1, root2);
        var t = dA / sB;
        predictivePosition = a + vA * t;
        return true;
    }

    void HorizontalRotation()
    {
        var ZXLeadPositionProjection = new Vector3(predictiveTargetPosition.x, horizontalRotator.position.y, predictiveTargetPosition.z);
        var horizontalAngle = Vector3.SignedAngle(horizontalRotator.forward, ZXLeadPositionProjection - horizontalRotator.position, Vector3.up);

        var updateAngle = horizontalRotationSpeed * (horizontalAngle / Mathf.Abs(horizontalAngle));
        if (Mathf.Abs(updateAngle) > Mathf.Abs(horizontalAngle))
            updateAngle = horizontalAngle;

        if (horizontalAngle != 0)
            horizontalRotator.Rotate(0, updateAngle, 0);
    }

    void VerticalRotation()
    {
        var ZYLeadPositionProjection = new Vector3(predictiveTargetPosition.x, verticalRotator.position.y, predictiveTargetPosition.z);
        var sign = predictiveTargetPosition.y < verticalRotator.position.y ? 1 : -1;
        var verticalAngle = Vector3.Angle(predictiveTargetPosition - verticalRotator.position, ZYLeadPositionProjection - verticalRotator.position) * sign - verticalRotator.localEulerAngles.x;

        var updateAngle = verticalRotationSpeed * (verticalAngle / Mathf.Abs(verticalAngle));
        if (Mathf.Abs(updateAngle) > Mathf.Abs(verticalAngle))
            updateAngle = verticalAngle;

        if (verticalRotator.localEulerAngles.x + updateAngle < maxVerticalRotationAngle && verticalRotator.localEulerAngles.x + updateAngle > -maxVerticalRotationAngle)
            verticalRotator.Rotate(updateAngle, 0, 0);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(verticalRotator.position, predictiveTargetPosition);
        Gizmos.DrawSphere(predictiveTargetPosition, 1);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(verticalRotator.position, verticalRotator.forward * 100);
    }
}
