﻿using System;
using System.Threading;
using System.Threading.Tasks;
using KafkaNet.Model;

namespace KafkaNet
{
    public interface IKafkaTcpSocket : IDisposable
    {
        /// <summary>
        /// The IP endpoint to the server.
        /// </summary>
        KafkaEndpoint Endpoint { get; }

        /// <summary>
        /// Read a certain byte array size return only when all bytes received.
        /// </summary>
        /// <param name="readSize">The size in bytes to receive from server.</param>
        /// <returns>Returns a byte[] array with the size of readSize.</returns>
        Task<byte[]> ReadAsync(int readSize);

        /// <summary>
        /// Read a certain byte array size return only when all bytes received.
        /// </summary>
        /// <param name="readSize">The size in bytes to receive from server.</param>
        /// <param name="cancellationToken">A cancellation token which will cancel the request.</param>
        /// <returns>Returns a byte[] array with the size of readSize.</returns>
        Task<byte[]> ReadAsync(int readSize, CancellationToken cancellationToken);

        /// <summary>
        /// Convenience function to write full buffer data to the server.
        /// </summary>
        /// <param name="buffer">The buffer data to send.</param>
        /// <returns>Returns Task handle to the write operation.</returns>
        Task<int> WriteAsync(byte[] buffer);

        /// <summary>
        /// Write the buffer data to the server.
        /// </summary>
        /// <param name="buffer">The buffer data to send.</param>
        /// <param name="cancellationToken">A cancellation token which will cancel the request.</param>
        /// <returns>Returns Task handle to the write operation.</returns>
        Task<int> WriteAsync(byte[] buffer, CancellationToken cancellationToken);
    }
}
