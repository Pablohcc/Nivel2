using UnityEngine;
using Unity.Cinemachine;

public class CineMachibeMovimientoCamara : MonoBehaviour
{
	public static CineMachibeMovimientoCamara Instance;	

	//private CinemachineVirtualCamera cinemachineVirtualCamera;

	private CinemachineCamera cinemachineCamera;

    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;

    private float TiempoMovimiento;

    private float tiempoMovimientoTotal;

    private float intensidadInicial;

   
	private void Awake()
	{
		Instance = this;
		cinemachineCamera = GetComponent<CinemachineCamera>();
		cinemachineBasicMultiChannelPerlin = cinemachineCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
	}

	public void MoverCamara(float intensidad, float frecuencia, float tiempo)
	{
		// Corregido: Sin el prefijo m_ para Cinemachine 3
		cinemachineBasicMultiChannelPerlin.AmplitudeGain = intensidad;
		cinemachineBasicMultiChannelPerlin.FrequencyGain = frecuencia;

		intensidadInicial = intensidad;
		tiempoMovimientoTotal = tiempo;

		// Corregido: Ahora coincide con el nombre de la línea 10
		TiempoMovimiento = tiempo;
	}

	private void Update()
	{
		if (TiempoMovimiento > 0)
		{
			TiempoMovimiento -= Time.deltaTime;
			cinemachineBasicMultiChannelPerlin.AmplitudeGain = Mathf.Lerp(intensidadInicial, 0, 1 -(TiempoMovimiento / tiempoMovimientoTotal));
		}
	}
}
