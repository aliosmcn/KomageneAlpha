
using UnityEngine;

/// <summary>
/// Kronometre sınıfı.
/// Bu sınıftan kalıtım alan sınıflar kronometre
/// özelliğine sahip olur.
/// Sınıf fonksiyonlar aracılığı ile yönetilir.
/// </summary>
public abstract class MonoTimer : MonoBehaviour
{
    /// <summary>
    /// Set edilen zaman
    /// </summary>
    private float settedTime = 5f;
    /// <summary>
    /// Timer'ın çalışıp çalışmadığını kontrol eden değişken
    /// </summary>
    private bool isStarted = false;
    /// <summary>
    /// Canlı olarak kalan zamanı tutan değişken.
    /// def val is zero
    /// </summary>
    private float remainingTime = 99999999999;
    
    protected virtual void Update()
    {
        if (!isStarted)
            return;
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0)
        {
            TimeIsUp();
            StopTimer();
        }
    }

    /// <summary>
    /// settedTime değişkenini değiştirir.
    /// settedTime değişkeninin değişmesi ile
    /// kronometrenin ne kadar sürede çalışacağı
    /// belirlenmiş olur.
    /// </summary>
    /// <param name="remTime"></param>
    protected void setRemainingTime(float remTime)
    {
        this.settedTime = remTime;
        this.remainingTime = remTime;
    }

    /// <summary>
    /// Kronometreyi başlatır.
    /// </summary>
    protected void StartTimer()
    {
        isStarted = true;
    }
    
    /// <summary>
    /// Kronometreyi durdurur.
    /// </summary>
    protected void PauseTimer()
    {
        isStarted = false;
    }

    /// <summary>
    /// Kronometrenin kalan zamanını daha önceden
    /// set edilen zamana geri getirir.
    /// </summary>
    protected void ResetTimer()
    {
        this.remainingTime = settedTime;
        isStarted = true;
    }

    /// <summary>
    /// Kronometreyi durdurur ve sıfırlar.
    /// </summary>
    protected void StopTimer()
    {
        PauseTimer();
        ResetTimer();
    }

    /// <summary>
    /// Kronometreyi sıfırlar ve yeniden başlatır.
    /// </summary>
    protected void RestartTimer()
    {
        StopTimer();
        StartTimer();
    }

    /// <summary>
    /// Kronometre de set edilen zaman
    /// geçtiğinde tetiklenir ve sürenin
    /// dolduğunu bildirir.
    /// </summary>
    protected abstract void TimeIsUp();

}
